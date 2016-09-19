using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IVeraControl.Model;
using VeraControl.Model.UpnpDevices.Base;

namespace VeraControl.Model.UpnpDevices
{
    public class HVAC_ZoneThermostat1: UpnpDeviceBase, IUpnpDevice
    {
        public string DeviceUrn { get; }
        public uint DeviceNumber { get; set; }
        public string DeviceName { get; }
    }
}
