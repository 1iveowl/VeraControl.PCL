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
        public IEnumerable<IUpnpAction> Actions { get; set; }
        public IEnumerable<IUpnpStateVariable> StateVariables { get; set; }
    }
}
