using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IVeraControl.Model;
using VeraControl.Model.UpnpService.Base;

namespace VeraControl.Model.UpnpService
{
    // Spec: http://upnp.org/specs/ha/UPnP-ha-TemperatureSetpoint-v1-Service.pdf
    public class TemperatureSetpoint1 : UpnpServiceBase, IUpnpService
    {
        public string ServiceUrn => "urn:schemas-upnp-org:service:TemperatureSetpoint:1 ";
        public string ServiceName => nameof(TemperatureSetpoint1);

        public TemperatureSetpoint1(IVeraController controller, IUpnpDevice device)
        {
            StateVariables = new List<UpnpStateVariable>
            {
                new UpnpStateVariable(controller, this, device)
                {
                  VariableName  = "CurrentSetPoint",
                  Type = typeof(double),
                  Value = null
                },
                new UpnpStateVariable(controller, this, device)
                {
                    VariableName = "SetpointAchieved",
                    Type = typeof(bool),
                    Value = null
                }
            };

            Actions = new List<UpnpAction>
            {
                new UpnpAction(controller, this, device)
                {
                    ActionName  = "SetCurrentSetpoint",
                    ArgumentName = "NewCurrentSetpoint",
                    Direction = Direction.In,
                    Type = typeof(double),
                    Value = null
                },
                new UpnpAction(controller, this, device)
                {
                    ActionName = "GetCurrentSetpoint",
                    ArgumentName = "CurrentSetpoint",
                    Direction = Direction.Out,
                    Type = typeof(double),
                    Value = null
                },
                new UpnpAction(controller, this, device)
                {
                    ActionName = "GetSetpointAchieved",
                    ArgumentName = "SetpointAchieved",
                    Direction = Direction.Out,
                    Type = typeof(bool),
                    Value = null
                }
            };
        }
    }
}
