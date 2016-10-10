using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IVeraControl.Model;
using VeraControl.Model.UpnpDevices.Base;
using VeraControl.Model.UpnpService;

namespace VeraControl.Model.UpnpDevices
{
    //Spec: http://upnp.org/specs/ha/UPnP-ha-Dimming-v1-Service.pdf
    public class Dimmer1 : UpnpDeviceBase, IUpnpDevice
    {
        public string DeviceUrn => "urn:schemas-upnp-org:service:Dimming:1";
        public string DeviceName => nameof(Dimmer1);

        public Dimmer1(IVeraController controller)
        {
            Services = new List<IUpnpService>
            {
                new SwitchPower1(controller, this),
                new UpnpService.Dimming1(controller, this)
            };
        }
    }
}
