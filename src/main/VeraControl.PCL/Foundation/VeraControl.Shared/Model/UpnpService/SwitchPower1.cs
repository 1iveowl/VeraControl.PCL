using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IVeraControl.Model;

namespace VeraControl.Model.UpnpService
{
    //Specification: http://upnp.org/specs/ha/UPnP-ha-SwitchPower-v1-Service.pdf
    public class SwitchPower1 : IUpnpService
    {
        public string ServiceUrn => "urn:upnp-org:serviceId:SwitchPower1";
        public string ServiceName { get; } = nameof(SwitchPower1);

        public IEnumerable<IUpnpStateVariable> StateVariables { get; set; } = new List<UpnpStateVariable>
        {
            new UpnpStateVariable
            {
                VariableName = "Target",
                Type = typeof(bool)
            },
            new UpnpStateVariable
            {
                VariableName = "Status",
                Type = typeof(bool)
            }
        };

        public IEnumerable<IUpnpAction> Actions { get; set; }

        public SwitchPower1(IVeraController controller)
        {
            Actions = new List<UpnpAction>
            {
                new UpnpAction(controller)
                {
                    ActionName = "SetTarget",
                    ArgumentName = "newTargetValue",
                    Type = typeof(bool),
                    Value = null,
                    Direction = Direction.In
                },
                new UpnpAction(controller)
                {
                    ActionName = "GetTarget",
                    ArgumentName = "RetTargetValue",
                    Type = typeof(bool),
                    Value = null,
                    Direction = Direction.Out
                },
                new UpnpAction(controller)
                {
                    ActionName = "GetStatus",
                    ArgumentName = "ResultStatus",
                    Type = typeof(bool),
                    Value = null,
                    Direction = Direction.Out
                }
            };
        }
    }
}
