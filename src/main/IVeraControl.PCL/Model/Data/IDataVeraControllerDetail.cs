namespace IVeraControl.Model.Data
{
    public interface IDataVeraControllerDetail
    {
        string PkDevice { get; }

        string MacAddress { get; }

        int Using_2G { get; }

        string ExternalIp { get; }

        string AccessiblePort { get; }

        string InternalIp { get; }

        string AliveDate { get; }

        string FirmwareVersion { get; }

        string PriorFirmwareVersion { get; }

        string UpgradeDate { get; }

        string Uptime { get; }

        string DeviceServer { get; }

        string EventServer { get; }

        string RelayServer { get; }

        string SupportServer { get; }

        string StorageServer { get; }

        string WifiSsid { get; }

        string Timezone { get; }

        string LocalPort { get; }

        string ZWaveLocale { get; set; }

        string ZWaveVersion { get; }

        string FkBranding { get; }

        string Platform { get; }

        string UiLanguage { get; }

        string UiSkin { get; }

        string HasWifi { get; }

        string HasAlarmPanel { get; }

        string Ui { get; }

        string EngineStatus { get; }

        int AccessPermissions { get; }
    }
}
