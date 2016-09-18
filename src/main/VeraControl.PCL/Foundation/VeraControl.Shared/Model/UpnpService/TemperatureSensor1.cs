using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IVeraControl.Model;

namespace VeraControl.Model.UpnpService
{
    public class TemperatureSensor1 : IUpnpService
    {
        public string ServiceUrn => "urn:schemas-upnp-org:service:TemperatureSensor:1";
        public string ServiceName => nameof(TemperatureSensor1);
        public IEnumerable<IUpnpAction> Actions { get; set; }
        public IEnumerable<IUpnpStateVariable> StateVariables { get; set; }
    }
}
