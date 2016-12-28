using System.Collections.Generic;
using IVeraControl.Model;
using UpnpModels.Model.UpnpService.Base;


namespace UpnpModels.Model.UpnpService
{
    public enum HumitidySensor1Action
    {
        GetCurrentHumitidy
    }

    public enum HumitidySensor1StateVariables
    {
        CurrentLevel
    }

    public class HumiditySensor1Service : UpnpServiceBase, IUpnpService
    {
        public string ServiceUrn => "urn:micasaverde-com:serviceId:HumiditySensor1";
        public string ServiceName => ServiceType.HumiditySensor1.ToString();

        public HumiditySensor1Service(IVeraController controller, IUpnpDevice device)
        {
            StateVariables = new List<UpnpStateVariable>
            {
                new UpnpStateVariable(controller, this, device)
                {
                    VariableName = HumitidySensor1StateVariables.CurrentLevel.ToString(),
                    Type = typeof(double),
                    Value = null
                }
            };

            Actions = new List<UpnpAction>
            {
                new UpnpAction(controller, this, device)
                {
                    ActionName = HumitidySensor1Action.GetCurrentHumitidy.ToString(),
                    ArgumentName = "CurrentLevel",
                    Direction = Direction.Out,
                    Type = typeof(double),
                    Value = null
                }
            };
        }
    }
}
