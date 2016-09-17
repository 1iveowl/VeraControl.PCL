using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IVeraControl.Model;
using IVeraControl.Model.Data;
using IVeraControl.Service;
using Newtonsoft.Json;

namespace VeraControl.Model.Json
{
    internal class JsonVeraController : IDataVeraController
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

        public IVeraControllerDetail ControllerDetail { get; protected set; } = null;

        public ConnectionType CurrentConnectionType { get; protected set; } = ConnectionType.Local;
    }
}
