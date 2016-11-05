using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IVeraControl.Model;
using UpnpModels.Model.UpnpDevice.Base;
using UpnpModels.Model.UpnpService;

namespace UpnpModels.Model.UpnpDevice
{
    public class HomeAutomationGateway : UpnpDeviceBase, IUpnpDevice
    {
        public string DeviceUrn => "urn:micasaverde-com:serviceId:SceneController1";
        public string DeviceName => nameof(HomeAutomationGateway);

        public HomeAutomationGateway(IVeraController controller)
        {
            Services = new List<IUpnpService>
            {
                new HomeAutomationGatewayService(controller, this),
            };
        }
    }
}
