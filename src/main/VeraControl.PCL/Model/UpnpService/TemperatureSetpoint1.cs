using VeraControl.Model.UpnpService.Base;

namespace VeraControl.Model.UpnpService
{
    public enum TemperatureSetpoint1Action
    {
        CurrentSetPoint,
        SetpointAchieved
    }

    public enum TemperatureSetpoint1StateVariable
    {
        SetCurrentSetpoint,
        GetCurrentSetpoint,
        GetSetpointAchieved
    }

    public class TemperatureSetpoint1 : UpnpServiceBase
    {
    }
}
