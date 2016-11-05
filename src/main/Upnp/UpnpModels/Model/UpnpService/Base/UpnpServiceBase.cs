using System.Collections.Generic;
using System.Linq;
using IVeraControl.Model;


namespace UpnpModels.Model.UpnpService.Base
{
    public abstract class UpnpServiceBase
    {
        public IEnumerable<IUpnpAction> Actions { get; set; }

        public IEnumerable<IUpnpStateVariable> StateVariables { get; set; }

        public virtual IUpnpAction LookupAction(dynamic actionName)
        {
            return Actions.FirstOrDefault(a => a.ActionName == actionName.ToString());
        }

        public virtual IUpnpStateVariable LookupStateVariable(dynamic stateVariableName)
        {
            var result = StateVariables.FirstOrDefault(v => v.VariableName == stateVariableName.ToString());
            return result;
        }
    }
}
