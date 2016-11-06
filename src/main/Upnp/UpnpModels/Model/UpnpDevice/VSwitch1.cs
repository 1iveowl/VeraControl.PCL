using System.Collections.Generic;
using IVeraControl.Model;
using UpnpModels.Model.UpnpDevice.Base;
using UpnpModels.Model.UpnpService;

namespace UpnpModels.Model.UpnpDevice
{
    public class VSwitch1 : UpnpDeviceBase, IUpnpDevice
    {
        public string DeviceUrn => "urn:schemas-upnp-org:device:VSwitch:1";
        public string DeviceName => nameof(VSwitch1);

        public VSwitch1(IVeraController controller)
        {
            Services = new List<IUpnpService> { new SwitchPower1(controller, this) };
        }
    }
}
