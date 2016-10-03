using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IVeraControl.Model;
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

    // Spec: http://upnp.org/specs/ha/UPnP-ha-TemperatureSetpoint-v1-Service.pdf
    public class TemperatureSetpoint1 : UpnpServiceBase, IUpnpService
    {
        public string ServiceUrn => "urn:upnp-org:serviceId:TemperatureSetpoint1";
        public string ServiceName => nameof(TemperatureSetpoint1);

        public TemperatureSetpoint1(IVeraController controller, IUpnpDevice device)
        {
            StateVariables = new List<UpnpStateVariable>
            {
                new UpnpStateVariable(controller, this, device)
                {
                  VariableName  = TemperatureSetpoint1Action.CurrentSetPoint.ToString(),
                  Type = typeof(double),
                  Value = null
                },
                new UpnpStateVariable(controller, this, device)
                {
                    VariableName = TemperatureSetpoint1Action.SetpointAchieved.ToString(),
                    Type = typeof(bool),
                    Value = null
                }
            };

            Actions = new List<UpnpAction>
            {
                new UpnpAction(controller, this, device)
                {
                    ActionName  = TemperatureSetpoint1StateVariable.SetCurrentSetpoint.ToString(),
                    ArgumentName = "NewCurrentSetpoint",
                    Direction = Direction.In,
                    Type = typeof(double),
                    Value = null
                },
                new UpnpAction(controller, this, device)
                {
                    ActionName = TemperatureSetpoint1StateVariable.GetCurrentSetpoint.ToString(),
                    ArgumentName = "CurrentSetpoint",
                    Direction = Direction.Out,
                    Type = typeof(double),
                    Value = null
                },
                new UpnpAction(controller, this, device)
                {
                    ActionName = TemperatureSetpoint1StateVariable.GetSetpointAchieved.ToString(),
                    ArgumentName = "SetpointAchieved",
                    Direction = Direction.Out,
                    Type = typeof(bool),
                    Value = null
                }
            };
        }
    }
}
