using System.Collections.Generic;
using System.Threading.Tasks;

namespace IVeraControl.Model
{
    public interface IUpnpDevice
    {
        string DeviceUrn { get; }
        uint DeviceNumber { get; set; }
        string DeviceName { get; }
        IEnumerable<IUpnpService> Services { get; set; }
        IUpnpService LookupService(dynamic serviceName);

        Task ActionAsync(dynamic actionName, dynamic target, ConnectionType connectionType);
    }
}
