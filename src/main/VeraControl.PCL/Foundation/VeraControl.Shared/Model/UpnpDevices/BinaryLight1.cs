using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IVeraControl.Model;
using VeraControl.Model.UpnpService;


namespace VeraControl.Model.UpnpDevices
{
    //Specification: http://upnp.org/specs/ha/UPnP-ha-BinaryLight-v1-Device.pdf
    public class BinaryLight1 : IUpnpDevice
    {
        public string DeviceUrn => "urn:schemas-upnp-org:device:BinaryLight:1";

        public string DeviceName => nameof(BinaryLight1);
        public uint DeviceNumber { get; set; }

        public IEnumerable<IUpnpService> Services { get; set; }

        public BinaryLight1(IVeraController controller)
        {
            Services = new List<IUpnpService> { new SwitchPower1(controller) };
        }

        public async Task SetTarget(bool target, ConnectionType connectionType)
        {
            var service = this.Services.FirstOrDefault(s => s.ServiceName == "SwitchPower1");
            var action = service.Actions.FirstOrDefault(a => a.ActionName == "SetTarget");

            action.Value = target.ToString();

            await action.SendAction(this, service, connectionType);

        }

        //public async Task<bool> GetStatus(uint deviceId)
        //{
        //    Services = this.Services.FirstOrDefault(s => s.)
        //}
    }
}
