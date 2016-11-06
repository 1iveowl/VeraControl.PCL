using System.Collections.Generic;
using IVeraControl.Model;
using UpnpModels.Model.UpnpService.Base;

namespace UpnpModels.Model.UpnpService
{
    // Spec: http://upnp.org/specs/ha/UPnP-ha-TemperatureSensor-v1-Service.pdf
    public enum TemperatureSensor1Action
    {
        GetCurrentTemperature
    }

    public enum TemperatureSensor1StateVariables
    {
        CurrentTemperature
    }

    public class TemperatureSensor1Service : UpnpServiceBase, IUpnpService
    {
        public string ServiceUrn => "urn:upnp-org:serviceId:TemperatureSensor1";
        public string ServiceName => ServiceType.TemperatureSensor1.ToString();

        public TemperatureSensor1Service(IVeraController controller, IUpnpDevice device)
        {
            StateVariables = new List<UpnpStateVariable>
            {
                new UpnpStateVariable(controller, this, device)
                {
                    VariableName = TemperatureSensor1StateVariables.CurrentTemperature.ToString(),
                    Type = typeof(double),
                    Value = null
                }
            };

            Actions = new List<UpnpAction>
            {
                new UpnpAction(controller, this, device)
                {
                    ActionName = TemperatureSensor1Action.GetCurrentTemperature.ToString(),
                    ArgumentName = "CurrentTemp",
                    Direction = Direction.Out,
                    Type = typeof(double),
                    Value = null
                }
            };
            }
    }
}
