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
        
        public IEnumerable<IUpnpAction> Actions { get; set; } = new List<UpnpAction>
            {
                new UpnpAction
                {
                    ActionName = "SetTarget",
                    ArgumentName = "newTargetValue",
                    Type = typeof(bool),
                    Value = null,
                    Direction = Direction.In
                },
                new UpnpAction
                {
                    ActionName = "GetTarget",
                    ArgumentName = "RetTargetValue",
                    Type = typeof(bool),
                    Value = null,
                    Direction = Direction.Out
                },
                new UpnpAction
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
