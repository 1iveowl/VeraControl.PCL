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

        public IVeraControllerDetail ControllerDetail { get; private set; } = null;
        public ConnectionType CurrentConnectionType { get; private set; } = ConnectionType.Local;

        public async Task GetDetailsAsync(IHttpConnectionService httpConnectionService, IIdentityPackage identityPackage)
        {
            var httpRequest = $"https://{ServerDevice}" +
                              $"/device" +
                              $"/device" +
                              $"/device" +
                              $"/{DeviceSerialId}";

            ControllerDetail = await GetAndDeserialize<VeraControllerDetail>(
                httpRequest, 
                httpConnectionService,
                identityPackage.IdentityBase64,
                identityPackage.IdentitySignature);

        }

        public Task EstablishConnection(ConnectionType connectionType = ConnectionType.Local)
        {
            CurrentConnectionType = connectionType;

            throw new NotImplementedException();
        }

    }
}
