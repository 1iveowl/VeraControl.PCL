﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;
using IVeraControl.Model;
using IVeraControl.Service;
using VeraControl.Helper;
using VeraControl.Model.Json;

namespace VeraControl.Model
{
    internal class VeraController : JsonVeraController, IVeraController
    {
        private readonly TimeSpan _sessionKeepAlive = TimeSpan.FromSeconds(60);

        private readonly HttpGetDeserializer _deserializer = new HttpGetDeserializer();
        private readonly IHttpConnectionService _httpConnectionService;
        private readonly IIdentityPackage _identityPackage;
        private readonly string _username;
        private readonly string _password;

        private string _sessionToken;

        private DateTime _lastTokenTime = default(DateTime);

        // Couldn't find documentation of how long a session is valid, but assume that it is at least one minute.
        private bool IsTokenExpired => DateTime.UtcNow > _lastTokenTime.Add(_sessionKeepAlive);

        internal VeraController()
        {
            
        }

        internal VeraController(
            IHttpConnectionService httpConnectionService,
            IIdentityPackage identityPackage,
            string username,
            string password)
        {
            _httpConnectionService = httpConnectionService;
            _identityPackage = identityPackage;
            _username = username;
            _password = password;
        }

        // Luup Request documentation: http://wiki.micasaverde.com/index.php/Luup_Requests
        // Exampel: http://ip_address:3480/data_request?id=action&output_format=xml&DeviceNum=6&serviceId=urn:upnp-org:serviceId:SwitchPower1&action=SetTarget&newTargetValue=0
        public async Task<bool> IsAliveAsync(ConnectionType connectionType)
        {
            var httpRequest = $"{await GetHttpAddress(connectionType)}" +
                              $"/data_request" +
                              $"?id=alive";

            return await DoHttpRequest(connectionType, httpRequest) == "OK";
        }

        public async Task<string> ReloadAsync(ConnectionType connectionType, bool waitUntilAliveAgain = true)
        {
            var httpRequest = $"{await GetHttpAddress(connectionType)}" +
                              $"/data_request" +
                              $"?id=reload";

            var result = await DoHttpRequest(connectionType, httpRequest);

            if (waitUntilAliveAgain)
            {
                await Task.Delay(TimeSpan.FromSeconds(3));

                while ((!await IsAliveAsync(connectionType)))
                {
                    await Task.Delay(TimeSpan.FromSeconds(1));
                }
            }

            return result;
        }

        public async Task<string> SendActionAsync(
            IUpnpDevice device,
            IUpnpService service,
            IUpnpAction action,
            ConnectionType connectionType)
        {
            CheckConnectionServiceAndIdentityPackage();
            await CheckIdentifyPackageValidity();

            if (device == null) throw new ArgumentException($"Device cannot be null");
            if (service == null) throw new ArgumentException($"Service cannot be null");
            if (action == null) throw new ArgumentException($"Action cannot be null");

            var httpRequest = $"{await GetHttpAddress(connectionType)}" +
                              $"/data_request" +
                              $"?id=action" +
                              $"&output_format=json" +
                              $"&DeviceNum={device.DeviceNumber}" +
                              $"&serviceId={service.ServiceUrn}" +
                              $"&action={action.ActionName}" +
                              $"&{action.ArgumentName}={action.Value}";

            return await DoHttpRequest(connectionType, httpRequest);
        }

        public async Task<string> VariableGetAsync(IUpnpDevice device, IUpnpService service, IUpnpStateVariable stateVariable, ConnectionType connectionType)
        {
            if (device == null) throw new ArgumentException($"Device cannot be null");
            if (service == null) throw new ArgumentException($"Service cannot be null");
            if (stateVariable == null) throw new ArgumentException($"State Variable cannot be null");

            var httpRequest = $"{await GetHttpAddress(connectionType)}" +
                              $"/data_request" +
                              $"?id=variableget" +
                              $"&output_format=json" +
                              $"&serviceId={service.ServiceUrn}" +
                              $"&DeviceNum={device.DeviceNumber}" +
                              $"&Variable={stateVariable.VariableName}";

            return await DoHttpRequest(connectionType, httpRequest);
        }

        public async Task<string> VariableSetAsync(IUpnpDevice device, IUpnpService service, IUpnpStateVariable stateVariable, ConnectionType connectionType)
        {
            if (device == null) throw new ArgumentException($"Device cannot be null");
            if (service == null) throw new ArgumentException($"Service cannot be null");
            if (stateVariable == null) throw new ArgumentException($"State Variable cannot be null");

            var httpRequest = $"{await GetHttpAddress(connectionType)}" +
                              $"/data_request" +
                              $"?id=variableset" +
                              $"&output_format=json" +
                              $"&serviceId={service.ServiceUrn}" +
                              $"&DeviceNum={device.DeviceNumber}" +
                              $"&Variable={stateVariable.VariableName}" +
                              $"&Value={stateVariable.Value}";

            return await DoHttpRequest(connectionType, httpRequest);
        }


        public async Task GetDetailsAsync()
        {
            CheckConnectionServiceAndIdentityPackage();

            var httpRequest = $"https://{ServerDevice}" +
                              $"/device" +
                              $"/device" +
                              $"/device" +
                              $"/{DeviceSerialId}";

            ControllerDetail = await _deserializer.GetAndDeserialize<VeraControllerDetail>(
                httpRequest,
                _httpConnectionService,
                _identityPackage.IdentityBase64,
                _identityPackage.IdentitySignature);

        }

        private async Task<string> DoHttpRequest(ConnectionType connectionType, string httpRequest)
        {
            if (connectionType == ConnectionType.Local)
            {
                return await _deserializer.GetString(
                httpRequest,
                _httpConnectionService);
            }
            else
            {
                return await _deserializer.GetString(
                httpRequest,
                _httpConnectionService,
                _identityPackage.IdentityBase64,
                _identityPackage.IdentitySignature);
            }
        }

        private async Task<string> GetHttpAddress(ConnectionType connectionType)
        {
            string httpAddr = null;
            switch (connectionType)
            {
                case ConnectionType.Local:
                    httpAddr = $"http://{ControllerDetail.InternalIp}/port_3480";
                    break;
                case ConnectionType.Remote:
                    {
                        if (IsTokenExpired)
                        {
                            _sessionToken = await GetRemoteSessionToken();
                            _lastTokenTime = DateTime.UtcNow;
                        }

                        httpAddr = $"https://{ControllerDetail.RelayServer}" +
                                    $"/relay/relay/relay/device" +
                                    $"/{DeviceSerialId}" +
                                    $"/session" +
                                    $"/{_sessionToken}" +
                                    $"/port_3480";
                        break;
                    }
            }
            return httpAddr;
        }

        private async Task<string> GetRemoteSessionToken()
        {
            var httpSessionRequest = $"https://{ControllerDetail.RelayServer}" +
                                     $"/info/session/token";

            return await _deserializer.GetString(
                httpSessionRequest,
                _httpConnectionService,
                _identityPackage.IdentityBase64,
                _identityPackage.IdentitySignature);
        }

        private void CheckConnectionServiceAndIdentityPackage()
        {
            if ((_httpConnectionService == null) || (_identityPackage == null))
                throw new ArgumentNullException($"{nameof(_httpConnectionService)} and/or {nameof(_identityPackage)} cannot be null");
        }

        private async Task CheckIdentifyPackageValidity()
        {
            if (_identityPackage.IsStale)
            {
                await _identityPackage.GetIdentityPackage(_username, _password);
            }
        }
    }
}
