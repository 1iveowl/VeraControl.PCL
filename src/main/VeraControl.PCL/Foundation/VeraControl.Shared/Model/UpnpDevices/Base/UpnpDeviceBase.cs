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

        public async Task<dynamic> ActionAsync(dynamic serviceName, dynamic actionName, dynamic target, ConnectionType connectionType)
        {
            var action = this.LookupService(serviceName).LookupAction(actionName) as IUpnpAction;

            if (action == null) throw new ArgumentException("Unable to find Action");

            action.Value = ConvertToActionRequestValueString(target, action.Type);

            return await action.SendAction(connectionType);
        }

        public async Task<dynamic> GetStateVariableAsync(dynamic serviceName, dynamic stateVariableName, ConnectionType connectionType)
        {
            var stateVariable =
                this.LookupService(serviceName).LookupStateVariable(stateVariableName) as IUpnpStateVariable;

            if (stateVariable == null) throw new ArgumentException("Unable to find State Variable");

            var result = await stateVariable.GetStateVariable(connectionType);

            return ConvertResponseValueType(result, stateVariable.Type);
        }

        public async Task SetStateVariableAsync(dynamic serviceName, dynamic stateVariableName, dynamic value,
            ConnectionType connectionType)
        {
            var stateVariable =
                this.LookupService(serviceName).LookupStateVariable(stateVariableName) as IUpnpStateVariable;

            if (stateVariable == null) throw new ArgumentException("Unable to find State Variable");

            string stringValue = ConvertToActionRequestValueString(value, stateVariable.Type);

            await stateVariable.SetStateVariable(stringValue, connectionType);
        }

        private dynamic ConvertResponseValueType(dynamic value, Type type)
        {

            if (type == typeof(bool))
            {
                return value == "1";
            }

            if (type == typeof(double))
            {
                double val;
                double.TryParse(value.ToString(), out val);
                return val;
            }

            return value.ToString();
        }

        private string ConvertToActionRequestValueString(dynamic value, Type type)
        {
            if (type == typeof(bool))
            {
                return value ? "1" : "0";
            }

            return value.ToString();
        }
    }
}
