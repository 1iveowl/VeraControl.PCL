using System;
using System.Collections.Generic;
using System.Globalization;
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
            var result = Services.FirstOrDefault(s => s.ServiceName == serviceName.ToString());
            return result;
        }

        public uint DeviceNumber { get; set; }

        public async Task<dynamic> ActionAsync(dynamic serviceName, dynamic actionName, dynamic target,
            ConnectionType connectionType)
        {
            var action = (IUpnpAction) this.LookupService(serviceName)?.LookupAction(actionName);

            if (action == null) throw new ArgumentException("Unable to find Action");

            action.Value = ConvertToActionRequestValueString(target, action.Type);

            return await action.SendAction(connectionType);
        }

        public async Task<dynamic> GetStateVariableAsync(dynamic serviceName, dynamic stateVariableName,
            ConnectionType connectionType)
        {
            var stateVariable =
                (IUpnpStateVariable) this.LookupService(serviceName)?.LookupStateVariable(stateVariableName);

            if (stateVariable == null) throw new ArgumentException("Unable to find State Variable");

            var result = await stateVariable.GetStateVariable(connectionType);

            return ConvertResponseValueType(result, stateVariable.Type);
        }

        public async Task<string> SetStateVariableAsync(dynamic serviceName, dynamic stateVariableName, dynamic value,
            ConnectionType connectionType)
        {
            var stateVariable =
                (IUpnpStateVariable) this.LookupService(serviceName)?.LookupStateVariable(stateVariableName);

            if (stateVariable == null) throw new ArgumentException("Unable to find State Variable");

            string stringValue = ConvertToActionRequestValueString(value, stateVariable.Type);

            return await stateVariable.SetStateVariable(stringValue, connectionType);
        }

        private dynamic ConvertResponseValueType(dynamic value, Type type)
        {
            if (string.IsNullOrEmpty(value.ToString()))
            {
                return null;
            }

            try
            {
                if (type == typeof(bool))
                {
                    return value == "1";
                }

                var result = Convert.ChangeType(value, type, CultureInfo.InvariantCulture);

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
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
