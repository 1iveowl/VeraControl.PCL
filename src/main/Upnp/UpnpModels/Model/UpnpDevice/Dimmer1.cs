using System.Collections.Generic;
using IVeraControl.Model;
using UpnpModels.Model.UpnpDevice.Base;
using UpnpModels.Model.UpnpService;

namespace UpnpModels.Model.UpnpDevice
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
                new Dimming1Service(controller, this)
            };
        }
    }
}
