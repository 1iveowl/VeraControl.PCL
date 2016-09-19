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
    // Spec: http://upnp.org/specs/ha/UPnP-ha-HVAC_ZoneThermostat-v1-Device.pdf 
    public class HVAC_ZoneThermostat1: UpnpDeviceBase, IUpnpDevice
    {
        public string DeviceUrn => "urn:schemas-upnp-org:device:HVAC_ZoneThermostat:1";
        public uint DeviceNumber { get; set; }
        public string DeviceName => nameof(HVAC_ZoneThermostat1);

        public HVAC_ZoneThermostat1(IVeraController controller)
        {
            Services = new List<IUpnpService>
            {
                new TemperatureSetpoint1(controller, this),
                new UpnpService.TemperatureSensor1(controller, this)
            };
        }
    }
}
