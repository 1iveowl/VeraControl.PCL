using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeraControl.Model.UpnpService.Base;

namespace VeraControl.Model.UpnpService
{
    public enum Dimming1Action
    {
        SetLoadLevelTarget,
    }

    public enum Dimming1StateVariable
    {
        LoadLevelTarget,
        LoadLevelStatus
    }
    public class Dimming1 : UpnpServiceBase
    {
    }
}
