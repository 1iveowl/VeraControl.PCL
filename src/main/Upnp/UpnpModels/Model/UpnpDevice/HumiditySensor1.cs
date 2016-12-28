using System.Collections.Generic;
using IVeraControl.Model;
using UpnpModels.Model.UpnpDevice.Base;
using UpnpModels.Model.UpnpService;

namespace UpnpModels.Model.UpnpDevice
{
    public class HumiditySensor1 : UpnpDeviceBase, IUpnpDevice
    {
        public string DeviceUrn => "urn:schemas-micasaverde-com:device:HumiditySensor:1 ";
        public string DeviceName => nameof(HumiditySensor1);

        public HumiditySensor1(IVeraController controller)
        {
            Services = new List<IUpnpService> { new HumiditySensor1Service(controller, this) };
        }
    }
}
