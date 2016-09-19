using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IVeraControl.Model;

namespace VeraControl.Model.UpnpService
{
    // Spec: http://upnp.org/specs/ha/UPnP-ha-TemperatureSensor-v1-Service.pdf
    public class TemperatureSensor1 : IUpnpService
    {
        public string ServiceUrn => "urn:schemas-upnp-org:service:TemperatureSensor:1";
        public string ServiceName => nameof(TemperatureSensor1);
        public IEnumerable<IUpnpAction> Actions { get; set; } = new List<UpnpAction>
        {
            new UpnpAction
            {
                ActionName = "GetCurrentTemperature",
                ArgumentName = "CurrentTemp",
                Direction = Direction.Out,
                Type = typeof(double),
                Value = null
            }
        };
        public IEnumerable<IUpnpStateVariable> StateVariables { get; set; } = new List<UpnpStateVariable>
        {
            new UpnpStateVariable
            {
                VariableName = "CurrentTemperature",
                Type = typeof(double),
                Value = null
            }
        };
    }
}
