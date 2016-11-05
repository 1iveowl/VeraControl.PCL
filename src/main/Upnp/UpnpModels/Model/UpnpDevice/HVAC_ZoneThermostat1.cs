using System.Collections.Generic;
using IVeraControl.Model;
using UpnpModels.Model.UpnpDevice.Base;
using UpnpModels.Model.UpnpService;

namespace UpnpModels.Model.UpnpDevice
{
    // Spec: http://upnp.org/specs/ha/UPnP-ha-HVAC_ZoneThermostat-v1-Device.pdf 
    public class HVAC_ZoneThermostat1: UpnpDeviceBase, IUpnpDevice
    {
        public string DeviceUrn => "urn:schemas-upnp-org:device:HVAC_ZoneThermostat:1";
        public string DeviceName => nameof(HVAC_ZoneThermostat1);

        public HVAC_ZoneThermostat1(IVeraController controller)
        {
            Services = new List<IUpnpService>
            {
                new TemperatureSetpoint1(controller, this),
                new TemperatureSensor1Service(controller, this)
            };
        }
    }
}
