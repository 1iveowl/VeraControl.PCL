using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;
using IVeraControl.Model;
using IVeraControl.Service;
using VeraControl.Model.Base;

namespace VeraControl.Model
{
    internal class VeraController : DeserializeBase, IVeraController
    {
        [JsonProperty(PropertyName = "PK_Device")]
        public string DeviceSerialId { get; set; }

        [JsonProperty(PropertyName = "MacAddress")]
        public string MacAddress { get; set; }

        [JsonProperty(PropertyName = "PK_DeviceType")]
        public int PkDeviceType { get; set; }

        [JsonProperty(PropertyName = "PK_DeviceSubType")]
        public int PkDeviceSubType { get; set; }

        [JsonProperty(PropertyName = "Server_Device")]
        public string ServerDevice { get; set; }

        [JsonProperty(PropertyName = "Server_Event")]
        public string ServerEvent { get; set; }

        [JsonProperty(PropertyName = "PK_Account")]
        public int PkAccount { get; set; }

        [JsonProperty(PropertyName = "Server_Account")]
        public string ServerAccount { get; set; }

        [JsonProperty(PropertyName = "InternalIP")]
        public string LocalIpAddress { get; set; }

        [JsonProperty(PropertyName = "LastAliveReported")]
        public string LastAliveReported { get; set; }

        //public bool ConnectionEstablished { get; private set; }

        public IHttpConnectionService HttpConnectionService { get; set; }

        public IVeraControllerDetail ControllerDetail { get; private set; } = null;

        public ConnectionType CurrentConnectionType { get; private set; } = ConnectionType.Local;

        private IIdentityPackage _identityPackage;

        // Luup Request documentation: http://wiki.micasaverde.com/index.php/Luup_Requests
        // Exampel: http://ip_address:3480/data_request?id=action&output_format=xml&DeviceNum=6&serviceId=urn:upnp-org:serviceId:SwitchPower1&action=SetTarget&newTargetValue=0
        //          https://vera-us-o:3480/data_request?id=action&output_format=json&DeviceNum4&serviceId=urn:upnp-org:serviceId:SwitchPower1&action=SetTarget&newTargetName=1 
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
                              $"?id=action" +
                              $"&output_format=json" +
                              $"&DeviceNum={device.DeviceNumber}" +
                              $"&serviceId={service.ServiceUrn}" +
                              $"&action={action.ActionName}" +
                              $"&{action.ArgumentName}={action.Value}";

            return await GetAndDeserialize<string>(
                httpRequest,
                HttpConnectionService,
                _identityPackage.IdentityBase64,
                _identityPackage.IdentitySignature);
        }



        public async Task GetDetailsAsync(IIdentityPackage identityPackage)
        {
            _identityPackage = identityPackage;
            CheckConnectionServiceAndIdentityPackage();

            var httpRequest = $"https://{ServerDevice}" +
                              $"/device" +
                              $"/device" +
                              $"/device" +
                              $"/{DeviceSerialId}";

            ControllerDetail = await GetAndDeserialize<VeraControllerDetail>(
                httpRequest,
                HttpConnectionService,
                _identityPackage.IdentityBase64,
                _identityPackage.IdentitySignature);

        }

        private void CheckConnectionServiceAndIdentityPackage()
        {
            if ((HttpConnectionService == null) || (_identityPackage == null))
                throw new ArgumentNullException($"{nameof(HttpConnectionService)} and/or {nameof(_identityPackage)} cannot be null");
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

            return await GetString(
                httpSessionRequest,
                HttpConnectionService,
                _identityPackage.IdentityBase64,
                _identityPackage.IdentitySignature);
        }
    }
}
