using System.Collections.Generic;
using IVeraControl.Model;
using UpnpModels.Model.UpnpDevice.Base;
using UpnpModels.Model.UpnpService;

namespace UpnpModels.Model.UpnpDevice
{
    public class VContainer1 : UpnpDeviceBase, IUpnpDevice
    {
        public string DeviceUrn => "urn:schemas-upnp-org:device:VContainer:1";
        public string DeviceName => nameof(VContainer1);

        public VContainer1(IVeraController controller)
        {
            Services = new List<IUpnpService> { new VContainer1Service(controller, this) };
        }
    }
}
