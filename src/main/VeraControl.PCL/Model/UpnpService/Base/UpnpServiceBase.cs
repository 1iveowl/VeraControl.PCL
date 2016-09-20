using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IVeraControl.Model;
using static VeraControl.Helper.Helper;

namespace VeraControl.Model.UpnpService.Base
{
    public class UpnpServiceBase : IUpnpService
    {
        public string ServiceUrn => null;
        public string ServiceName => null;
        public IEnumerable<IUpnpAction> Actions { get; set; }
        public IEnumerable<IUpnpStateVariable> StateVariables { get; set; }
        public IUpnpAction LookupAction(dynamic actionName)
        {
            throw new NotImplementedException(BaitNoSwitch);
        }

        public IUpnpStateVariable LookupStateVariable(dynamic stateVariableName)
        {
            throw new NotImplementedException(BaitNoSwitch);
        }
    }
}
