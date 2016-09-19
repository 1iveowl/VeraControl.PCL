using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IVeraControl.Model;
using VeraControl.Model.UpnpService.Base;

namespace VeraControl.Model.UpnpService
{
    public class VContainer1Service : UpnpServiceBase, IUpnpService
    {
        public string ServiceUrn => "urn:upnp-org:serviceId:VContainer1";
        public string ServiceName => "VContainer1";

        public override IUpnpAction LookupAction(dynamic actionName)
        {
            throw new NotImplementedException("There are no actions for this service and the LookupAction method is not implemented");
        }

        public VContainer1Service(IVeraController controller, IUpnpDevice device)
        {
            StateVariables = new List<UpnpStateVariable>
            {
                new UpnpStateVariable(controller, this, device)
                {
                    VariableName = "VariableName1",
                    Type = typeof(string)
                },
                new UpnpStateVariable(controller, this, device)
                {
                    VariableName = "VariableName2",
                    Type = typeof(string)
                },
                new UpnpStateVariable(controller, this, device)
                {
                    VariableName = "VariableName3",
                    Type = typeof(string)
                },
                new UpnpStateVariable(controller, this, device)
                {
                    VariableName = "VariableName4",
                    Type = typeof(string)
                },
                new UpnpStateVariable(controller, this, device)
                {
                    VariableName = "Variable1",
                    Type = typeof(string)
                },
                new UpnpStateVariable(controller, this, device)
                {
                    VariableName = "Variable2",
                    Type = typeof(string)
                },
                new UpnpStateVariable(controller, this, device)
                {
                    VariableName = "Variable3",
                    Type = typeof(string)
                },
                new UpnpStateVariable(controller, this, device)
                {
                    VariableName = "Variable4",
                    Type = typeof(string)
                },
            };
        }
    }
}
