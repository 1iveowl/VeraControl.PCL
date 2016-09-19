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

    public class SwitchPower1 : UpnpServiceBase, IUpnpService
    {
        public string ServiceUrn => "urn:upnp-org:serviceId:SwitchPower1";
        public string ServiceName { get; } = ServiceType.SwitchPower1.ToString();

        public SwitchPower1(IVeraController controller, IUpnpDevice device)
        {
            StateVariables = new List<UpnpStateVariable>
        {
            new UpnpStateVariable(controller, this, device)
            {
                VariableName = SwitchPower1StateVariable.Target.ToString(),
                Type = typeof(bool)
            },
            new UpnpStateVariable(controller, this, device)
            {
                VariableName = SwitchPower1StateVariable.Status.ToString(),
                Type = typeof(bool)
            }
        };

            Actions = new List<UpnpAction>
            {
                new UpnpAction(controller, this, device)
                {
                    ActionName = SwitchPower1Action.SetTarget.ToString(),
                    ArgumentName = "newTargetValue",
                    Type = typeof(bool),
                    Value = null,
                    Direction = Direction.In
                },
                new UpnpAction(controller, this, device)
                {
                    ActionName = SwitchPower1Action.GetTarget.ToString(),
                    ArgumentName = "RetTargetValue",
                    Type = typeof(bool),
                    Value = null,
                    Direction = Direction.Out
                },
                new UpnpAction(controller, this, device)
                {
                    ActionName = SwitchPower1Action.GetStatus.ToString(),
                    ArgumentName = "ResultStatus",
                    Type = typeof(bool),
                    Value = null,
                    Direction = Direction.Out
                }
            };
        }
    }
}
