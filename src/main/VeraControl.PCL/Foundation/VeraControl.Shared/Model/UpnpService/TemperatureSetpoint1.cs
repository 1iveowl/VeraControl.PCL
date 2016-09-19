using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IVeraControl.Model;

namespace VeraControl.Model.UpnpService
{
    // Spec: http://upnp.org/specs/ha/UPnP-ha-TemperatureSetpoint-v1-Service.pdf
    public class TemperatureSetpoint1 : IUpnpService
    {
        public string ServiceUrn => "urn:schemas-upnp-org:service:TemperatureSetpoint:1 ";
        public string ServiceName => nameof(TemperatureSetpoint1);
        public IEnumerable<IUpnpAction> Actions { get; set; } = new List<UpnpAction>
        {
            new UpnpAction
            {
                ActionName  = "SetCurrentSetpoint",
                ArgumentName = "NewCurrentSetpoint",
                Direction = Direction.In,
                Type = typeof(double),
                Value = null
            },
            new UpnpAction
            {
                ActionName = "GetCurrentSetpoint",
                ArgumentName = "CurrentSetpoint",
                Direction = Direction.Out,
                Type = typeof(double),
                Value = null
            },
            new UpnpAction
            {
                ActionName = "GetSetpointAchieved",
                ArgumentName = "SetpointAchieved",
                Direction = Direction.Out,
                Type = typeof(bool),
                Value = null
            }
        };
        public IEnumerable<IUpnpStateVariable> StateVariables { get; set; } = new List<UpnpStateVariable>
        {
            new UpnpStateVariable
            {
              VariableName  = "CurrentSetPoint",
              Type = typeof(double),
              Value = null
            },
            new UpnpStateVariable
            {
                VariableName = "SetpointAchieved",
                Type = typeof(bool),
                Value = null
            }
        };
    }
}
