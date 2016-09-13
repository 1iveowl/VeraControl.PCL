using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IVeraControl.Model;
using VeraControl.Model.UpnpService;


namespace VeraControl.Model.UpnpDevices
{
    public class BinaryLight1 : IUpnpDevice
    {
        public string DeviceUrn => "urn:schemas-upnp-org:device:BinaryLight:1";
        public string DeviceNumber { get; set; }

        public SwitchPower1 SwitchPower1 { get; } = new SwitchPower1();
    }
}
