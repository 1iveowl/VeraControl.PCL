using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IVeraControl.Model;
using VeraControl.Model.UpnpService;

namespace VeraControl.Model.UpnpDevices
{
    public class VSwitch1 : IUpnpDevice
    {
        public string DeviceUrn => "urn:schemas-upnp-org:device:VSwitch:1";
        public uint DeviceNumber { get; set; }
        public string DeviceName => nameof(VSwitch1);
        public IEnumerable<IUpnpService> Services { get; set; } = new List<IUpnpService> { new SwitchPower1() };
    }
}
