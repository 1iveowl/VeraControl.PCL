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

        Task<dynamic> ActionAsync(dynamic serviceName, dynamic actionName, dynamic target, 
            ConnectionType connectionType);

        Task<dynamic> GetStateVariableAsync(dynamic serviceName, dynamic stateVariableName,
            ConnectionType connectionType);

        Task<string> SetStateVariableAsync(dynamic serviceName, dynamic stateVariableName, dynamic value,
            ConnectionType connectionType);
    }
}
