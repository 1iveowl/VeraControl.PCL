using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Bluetooth.Rfcomm;

namespace VeraControl.Model.UpnpService
{
    internal class SSwitchPower1
    {
        internal string ServiceId => "serviceId=urn:upnp-org:serviceId:SwitchPower1";

        internal void SetTarget(bool value)
        {
            
        }
    }
}
