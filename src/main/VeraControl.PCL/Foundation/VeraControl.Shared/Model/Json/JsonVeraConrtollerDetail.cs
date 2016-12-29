using IVeraControl.Model.Data;
using Newtonsoft.Json;

namespace VeraControl.Model.Json
{
    internal class JsonVeraConrtollerDetail : IDataVeraControllerDetail
    {
        [JsonProperty(PropertyName = "PK_Device")]
        public string PkDevice { get; set; }

        [JsonProperty(PropertyName = "MacAddress")]
        public string MacAddress { get; set; }

        [JsonProperty(PropertyName = "Using_2G")]
        public int Using_2G { get; set; }

        [JsonProperty(PropertyName = "ExternalIP")]
        public string ExternalIp { get; set; }

        [JsonProperty(PropertyName = "AccessiblePort")]
        public string AccessiblePort { get; set; }

        [JsonProperty(PropertyName = "InternalIP")]
        public string InternalIp { get; set; }

        [JsonProperty(PropertyName = "AliveDate")]
        public string AliveDate { get; set; }

        [JsonProperty(PropertyName = "FirmwareVersion")]
        public string FirmwareVersion { get; set; }

        [JsonProperty(PropertyName = "PriorFirmwareVersion")]
        public string PriorFirmwareVersion { get; set; }

        [JsonProperty(PropertyName = "UpgradeDate")]
        public string UpgradeDate { get; set; }

        [JsonProperty(PropertyName = "Uptime")]
        public string Uptime { get; set; }

        [JsonProperty(PropertyName = "Server_Device")]
        public string DeviceServer { get; set; }

        [JsonProperty(PropertyName = "Server_Event")]
        public string EventServer { get; set; }

        [JsonProperty(PropertyName = "Server_Relay")]
        public string RelayServer { get; set; }

        [JsonProperty(PropertyName = "Server_Support")]
        public string SupportServer { get; set; }

        [JsonProperty(PropertyName = "Server_Storage")]
        public string StorageServer { get; set; }

        [JsonProperty(PropertyName = "WifiSsid")]
        public string WifiSsid { get; set; }

        [JsonProperty(PropertyName = "Timezone")]
        public string Timezone { get; set; }

        [JsonProperty(PropertyName = "LocalPort")]
        public string LocalPort { get; set; }

        [JsonProperty(PropertyName = "ZWaveLocale")]
        public string ZWaveLocale { get; set; }

        [JsonProperty(PropertyName = "ZWaveVersion")]
        public string ZWaveVersion { get; set; }

        [JsonProperty(PropertyName = "FK_Branding")]
        public string FkBranding { get; set; }

        [JsonProperty(PropertyName = "Platform")]
        public string Platform { get; set; }

        [JsonProperty(PropertyName = "UILanguage")]
        public string UiLanguage { get; set; }

        [JsonProperty(PropertyName = "UISkin")]
        public string UiSkin { get; set; }

        [JsonProperty(PropertyName = "HasWifi")]
        public string HasWifi { get; set; }

        [JsonProperty(PropertyName = "HasAlarmPanel")]
        public string HasAlarmPanel { get; set; }

        [JsonProperty(PropertyName = "UI")]
        public string Ui { get; set; }

        [JsonProperty(PropertyName = "EngineStatus")]
        public string EngineStatus { get; set; }

        [JsonProperty(PropertyName = "AccessPermissions")]
        public int AccessPermissions { get; set; }
    }
}
