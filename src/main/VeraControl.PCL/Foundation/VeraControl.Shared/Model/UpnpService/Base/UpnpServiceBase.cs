using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IVeraControl.Model;

namespace VeraControl.Model.UpnpService.Base
{
    public abstract class UpnpServiceBase
    {
        public IEnumerable<IUpnpAction> Actions { get; set; }

        public virtual IUpnpAction LookupAction(dynamic actionName)
        {
            return Actions.FirstOrDefault(a => a.ActionName == actionName.ToString());
        }
    }
}
