using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeraControl.Model.UpnpService.Base;

namespace VeraControl.Model.UpnpService
{
    public enum SwitchPower1Action
    {
        SetTarget,
        GetTarget,
        GetStatus
    }

    public enum SwitchPower1StateVariable
    {
        Target,
        Status
    }
    public class SwitchPower1 : UpnpServiceBase
    {
        
    }
}
