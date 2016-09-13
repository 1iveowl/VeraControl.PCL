namespace IVeraControl.Model
{
    public interface IUpnpDevice
    {
        string DeviceUrn { get; }
        string DeviceNumber { get; set; }
    }
}
