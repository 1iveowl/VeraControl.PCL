using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IVeraControl.Model;

namespace VeraControl.Model.UpnpService
{
    public class SwitchPower1 : IUpnpService
    {
        public string ServiceUrn => "serviceId=urn:upnp-org:serviceId:SwitchPower1";

        //Specification: http://upnp.org/specs/ha/UPnP-ha-SwitchPower-v1-Service.pdf
        public IAction SetTarget(bool newTargetValue)
        {
            return new Action
            {
                ActionName = "SetTarget",
                ArgumentName = "newTargetName",
                Type = typeof(bool),
                Value = newTargetValue.ToString(),
                Direction = Direction.In
            };
        }

        public IAction GetTarget()
        {
            return new Action
            {
                ActionName = "GetTarget",
                ArgumentName = "RetTargetValue",
                Type = typeof(bool),
                Value = null,
                Direction = Direction.Out
            };
        }

        public IAction GetStatus()
        {
            return new Action
            {
                ActionName = "GetStatus",
                ArgumentName = "ResultStatus",
                Type = typeof(bool),
                Value = null,
                Direction = Direction.Out
            };
        }
    }
}
