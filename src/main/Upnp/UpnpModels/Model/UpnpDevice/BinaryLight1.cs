using System.Collections.Generic;
using IVeraControl.Model;
using UpnpModels.Model.UpnpDevice.Base;
using UpnpModels.Model.UpnpService;

namespace UpnpModels.Model.UpnpDevice
{
    //Specification: http://upnp.org/specs/ha/UPnP-ha-BinaryLight-v1-Device.pdf
    public class BinaryLight1 : UpnpDeviceBase, IUpnpDevice
    {
        public string DeviceUrn => "urn:schemas-upnp-org:device:BinaryLight:1";

        public string DeviceName => nameof(BinaryLight1);
       

        public BinaryLight1(IVeraController controller)
        {
            Services = new List<IUpnpService> { new SwitchPower1(controller, this) };
        }
    }
}
