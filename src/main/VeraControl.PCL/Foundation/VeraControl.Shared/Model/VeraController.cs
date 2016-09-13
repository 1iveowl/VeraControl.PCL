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

        public async Task<string> SendAction(IUpnpDevice device, IUpnpService service, string value, string actionName, ConnectionType connectionType)
        {
            CheckConnectionServiceAndIdentityPackage();

            var action = service?.Actions?.FirstOrDefault(x => x.ActionName == actionName);

            if (action == null) throw new ArgumentException($"No action matches action name: {actionName}");

            var httpRequest = $"https://{GetHttpAddress(connectionType)}" +
                              $"/data_request" +
                              $"?id=action" +
                              $"&output_format=json" +
                              $"&DeviceNum={device.DeviceNumber}" +
                              $"&serviceId={service.ServiceUrn}" +
                              $"&action={action.ActionName}" +
                              $"&{action.ArgumentName}={action.Value}";
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
                identityPackage.IdentityBase64,
                identityPackage.IdentitySignature);

        }

        private void CheckConnectionServiceAndIdentityPackage()
        {
            if ((HttpConnectionService == null) || (_identityPackage == null))
                throw new ArgumentNullException($"{nameof(HttpConnectionService)} and/or {nameof(_identityPackage)} cannot be null");
        }


        private string GetHttpAddress(ConnectionType connectionType)
        {
            string httpAddr = null;
            switch (connectionType)
            {
                case ConnectionType.Local:
                    httpAddr = $"{LocalIpAddress}:3480";
                    break;
                case ConnectionType.Remote:
                    httpAddr = $"{ServerDevice}:3480";
                    break;
            }
            return httpAddr;
        }
        //public async Task EstablishConnection(ConnectionType connectionType = ConnectionType.Local)
        //{
        //    CurrentConnectionType = connectionType;

        //    switch (connectionType)
        //    {
        //        case ConnectionType.Local:
        //            await EstablishLocalConnection();
        //            break;
        //        case ConnectionType.Remote:
        //            await EstablishRemoteConnection();
        //            break;
        //        default:
        //            throw new ArgumentOutOfRangeException(nameof(connectionType), connectionType, null);
        //    }
        //}

        //private async Task EstablishLocalConnection()
        //{

        //}

        //private async Task EstablishRemoteConnection()
        //{

        //}
    }
}
