using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IVeraControl.Model;
using UpnpModels.Model.UpnpService.Base;

namespace UpnpModels.Model.UpnpService
{
    public enum HomeAutomationGatewayAction
    {
        RunScene,
    }

    public enum HomeAutomationGatwayStateVariable
    {
        None
    }

    public class HomeAutomationGatewayService : UpnpServiceBase, IUpnpService
    {
        public string ServiceUrn => "urn:micasaverde-com:serviceId:HomeAutomationGateway1";
        public string ServiceName { get; } = ServiceType.HomeAutomationGateway1.ToString();

        public HomeAutomationGatewayService(IVeraController controller, IUpnpDevice device)
        {
            //StateVariables = new List<IUpnpStateVariable>
            //{
            //    new UpnpStateVariable(controller, this, device)
            //    {
            //        VariableName = HomeAutomationGatwayStateVariable.None.ToString(),
            //        Type = typeof(int),
            //    }
            //};

            Actions = new List<IUpnpAction>
            {
                new UpnpAction(controller, this, device)
                {
                    ActionName = HomeAutomationGatewayAction.RunScene.ToString(),
                    ArgumentName = "SceneNum",
                    Type = typeof(int),
                    Value = null,
                    Direction = Direction.In
                }
            };
        }
    }
}
