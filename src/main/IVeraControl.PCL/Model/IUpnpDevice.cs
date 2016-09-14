using System.Collections.Generic;

namespace IVeraControl.Model
{
    public interface IUpnpDevice
    {
        string DeviceUrn { get; }
        string DeviceNumber { get; set; }
        string DeviceName { get; }
        IEnumerable<IUpnpService> Services { get; set; }
    }
}
