using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IVeraControl.Model;

namespace VeraControl.Model.UpnpDevices.Base
{
    public abstract class UpnpDeviceBase
    {
        public IEnumerable<IUpnpService> Services { get; set; }

        public virtual IUpnpService LookupService(dynamic serviceName)
        {
            return Services.FirstOrDefault(s => s.ServiceName == serviceName.ToString());
        }

        public async Task ActionAsync(dynamic serviceName, dynamic actionName, dynamic target, ConnectionType connectionType)
        {
            var action = this.LookupService(serviceName).LookupAction(actionName) as IUpnpAction;

            if (action == null) throw new ArgumentException("Unable to find Action");

            if (action.Type == typeof(bool))
            {
                action.Value = target ? "1" : "0";
            }
            else
            {
                action.Value = target.ToString();
            }

            await action.SendAction(connectionType);
        }

        public async Task<dynamic> GetStateVariableAsync(dynamic serviceName, dynamic stateVariableName, ConnectionType connectionType)
        {
            var stateVariable =
                this.LookupService(serviceName).LookupStateVariable(stateVariableName) as IUpnpStateVariable;

            if (stateVariable == null) throw new ArgumentException("Unable to find State Variable");

            var result = await stateVariable.GetStateVariable(connectionType);

            if (stateVariable.Type == typeof(bool))
            {
                return (result == "1");
            }
            else
            {
                return result;
            }
        }

        public async Task SetStateVariableAsync(dynamic serviceName, dynamic stateVariableName, dynamic value,
            ConnectionType connectionType)
        {
            var stateVariable =
                this.LookupService(serviceName).LookupStateVariable(stateVariableName) as IUpnpStateVariable;

            if (stateVariable == null) throw new ArgumentException("Unable to find State Variable");

            await stateVariable.SetStateVariable(value.ToString(), connectionType);
        }
    }
}
