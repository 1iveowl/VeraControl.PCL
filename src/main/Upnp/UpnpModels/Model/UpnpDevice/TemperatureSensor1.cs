using System.Collections.Generic;
using IVeraControl.Model;
using UpnpModels.Model.UpnpDevice.Base;
using UpnpModels.Model.UpnpService;

namespace UpnpModels.Model.UpnpDevice
{
    // Spec: http://upnp.org/specs/ha/UPnP-ha-TemperatureSensor-v1-Service.pdf
    public class TemperatureSensor1 : UpnpDeviceBase, IUpnpDevice
    {
        public string DeviceUrn => "urn:schemas-upnp-org:service:TemperatureSensor:1 ";
        public string DeviceName => nameof(TemperatureSensor1);

        public TemperatureSensor1(IVeraController controller)
        {
            Services = new List<IUpnpService> {new TemperatureSensor1Service(controller, this)};
        }
    }
}
