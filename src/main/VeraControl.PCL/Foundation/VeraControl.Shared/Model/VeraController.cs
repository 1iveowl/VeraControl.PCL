using System;
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
        private readonly HttpGetDeserializer _deserializer = new HttpGetDeserializer();

        private readonly IHttpConnectionService _httpConnectionService;

        private readonly IIdentityPackage _identityPackage;

        internal VeraController()
        {
            
        }

        internal VeraController(
            IHttpConnectionService httpConnectionService,
            IIdentityPackage identityPackage)
        {
            _httpConnectionService = httpConnectionService;
            _identityPackage = identityPackage;
        }

        // Luup Request documentation: http://wiki.micasaverde.com/index.php/Luup_Requests
        // Exampel: http://ip_address:3480/data_request?id=action&output_format=xml&DeviceNum=6&serviceId=urn:upnp-org:serviceId:SwitchPower1&action=SetTarget&newTargetValue=0
        public async Task<string> SendAction(
            IUpnpDevice device,
            IUpnpService service,
            IUpnpAction action,
            ConnectionType connectionType)
        {
            CheckConnectionServiceAndIdentityPackage();

            if (device == null) throw new ArgumentException($"Device cannot be null");

            if (service == null) throw new ArgumentException($"Service cannot be null");

            if (action == null) throw new ArgumentException($"Action cannot be null");

            var httpRequest = $"https://{await GetHttpAddress(connectionType)}" +
                              $"/data_request" +
                              $"?id=lu_action" +
                              $"&output_format=json" +
                              $"&DeviceNum={device.DeviceNumber}" +
                              $"&serviceId={service.ServiceUrn}" +
                              $"&action={action.ActionName}" +
                              $"&{action.ArgumentName}={action.Value}";

            return await _deserializer.GetString(
                httpRequest,
                _httpConnectionService,
                _identityPackage.IdentityBase64,
                _identityPackage.IdentitySignature);
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

        private void CheckConnectionServiceAndIdentityPackage()
        {
            if ((_httpConnectionService == null) || (_identityPackage == null))
                throw new ArgumentNullException($"{nameof(_httpConnectionService)} and/or {nameof(_identityPackage)} cannot be null");
        }


        private async Task<string> GetHttpAddress(ConnectionType connectionType)
        {
            string httpAddr = null;
            switch (connectionType)
            {
                case ConnectionType.Local:
                    httpAddr = $"{LocalIpAddress}/port_3480";
                    break;
                case ConnectionType.Remote:
                    {
                        var token = await GetRemoteSessionToken();

                        httpAddr = $"{ControllerDetail.RelayServer}" +
                                    $"/relay/relay/relay/device" +
                                    $"/{DeviceSerialId}" +
                                    $"/session" +
                                    $"/{token}" +
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
    }
}
