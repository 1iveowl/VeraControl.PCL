using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IVeraControl.Model;
using VeraControl.Model.UpnpService.Base;

namespace VeraControl.Model.UpnpService
{
    //Specification: http://upnp.org/specs/ha/UPnP-ha-SwitchPower-v1-Service.pdf
    public class SwitchPower1 : UpnpServiceBase, IUpnpService
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

        

        public SwitchPower1(IVeraController controller, IUpnpDevice device)
        {
            Actions = new List<UpnpAction>
            {
                new UpnpAction(controller, this, device)
                {
                    ActionName = "SetTarget",
                    ArgumentName = "newTargetValue",
                    Type = typeof(bool),
                    Value = null,
                    Direction = Direction.In
                },
                new UpnpAction(controller, this, device)
                {
                    ActionName = "GetTarget",
                    ArgumentName = "RetTargetValue",
                    Type = typeof(bool),
                    Value = null,
                    Direction = Direction.Out
                },
                new UpnpAction(controller, this, device)
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
