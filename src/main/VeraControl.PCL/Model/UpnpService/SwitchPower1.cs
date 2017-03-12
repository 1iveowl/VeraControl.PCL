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
