using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IVeraControl.Model;
using static VeraControl.Helper.Helper;

namespace VeraControl.Model.UpnpDevices.Base
{
    public abstract class UpnpDeviceBase : IUpnpDevice
    {
        public string DeviceUrn => null;
        public uint DeviceNumber { get; set; }
        public string DeviceName => null;

        public IEnumerable<IUpnpService> Services { get; set; }

        public virtual IUpnpService LookupService(dynamic serviceName)
        {
            throw new NotImplementedException(BaitNoSwitch);
        }

        public Task<dynamic> ActionAsync(dynamic serviceName, dynamic actionName, dynamic target,
            ConnectionType connectionType)
        {
            throw new NotImplementedException(BaitNoSwitch);
        }

        public Task<dynamic> GetStateVariableAsync(dynamic serviceName, dynamic stateVariableName,
            ConnectionType connectionType)
        {
            throw new NotImplementedException(BaitNoSwitch);
        }

        public Task<string> SetStateVariableAsync(dynamic serviceName, dynamic stateVariableName, dynamic value,
            ConnectionType connectionType)
        {
            throw new NotImplementedException(BaitNoSwitch);
        }
    }
}
