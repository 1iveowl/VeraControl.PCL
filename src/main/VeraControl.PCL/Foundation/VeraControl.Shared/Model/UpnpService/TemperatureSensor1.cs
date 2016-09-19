using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IVeraControl.Model;
using VeraControl.Model.UpnpService.Base;

namespace VeraControl.Model.UpnpService
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

    public class TemperatureSensor1 : UpnpServiceBase, IUpnpService
    {
        public string ServiceUrn => "urn:schemas-upnp-org:service:TemperatureSensor:1";
        public string ServiceName => nameof(TemperatureSensor1);

        public TemperatureSensor1(IVeraController controller, IUpnpDevice device)
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
