using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IVeraControl.Model;
using VeraControl.Model.UpnpDevices.Base;

namespace VeraControl.Model.UpnpDevices
{
    // Spec: http://upnp.org/specs/ha/UPnP-ha-TemperatureSensor-v1-Service.pdf
    public class TemperatureSensor1 : UpnpDeviceBase, IUpnpDevice
    {
        public string DeviceUrn => "urn:schemas-upnp-org:service:TemperatureSensor:1 ";
        public string DeviceName => nameof(TemperatureSensor1);

        public TemperatureSensor1(IVeraController controller)
        {
            Services = new List<IUpnpService> {new UpnpService.TemperatureSensor1Service(controller, this)};
        }
    }
}
