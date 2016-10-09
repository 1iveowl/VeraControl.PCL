using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IVeraControl.Model;
using VeraControl.Model.UpnpService.Base;

namespace VeraControl.Model.UpnpService
{
    public enum VContainer1Action
    {
        NoActionsDefined
    }

    public enum VContainer1StateVariable
    {
        VariableName1,
        VariableName2,
        VariableName3,
        VariableName4,
        VariableName5,
        Variable1,
        Variable2,
        Variable3,
        Variable4,
        Variable5,
    }

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
                    VariableName = VContainer1StateVariable.VariableName1.ToString(),
                    Type = typeof(string)
                },
                new UpnpStateVariable(controller, this, device)
                {
                    VariableName = VContainer1StateVariable.VariableName2.ToString(),
                    Type = typeof(string)
                },
                new UpnpStateVariable(controller, this, device)
                {
                    VariableName = VContainer1StateVariable.VariableName3.ToString(),
                    Type = typeof(string)
                },
                new UpnpStateVariable(controller, this, device)
                {
                    VariableName = VContainer1StateVariable.VariableName4.ToString(),
                    Type = typeof(string)
                },
                new UpnpStateVariable(controller, this, device)
                {
                    VariableName = VContainer1StateVariable.VariableName5.ToString(),
                    Type = typeof(string)
                },
                new UpnpStateVariable(controller, this, device)
                {
                    VariableName = VContainer1StateVariable.Variable1.ToString(),
                    Type = typeof(string)
                },
                new UpnpStateVariable(controller, this, device)
                {
                    VariableName = VContainer1StateVariable.Variable2.ToString(),
                    Type = typeof(string)
                },
                new UpnpStateVariable(controller, this, device)
                {
                    VariableName = VContainer1StateVariable.Variable3.ToString(),
                    Type = typeof(string)
                },
                new UpnpStateVariable(controller, this, device)
                {
                    VariableName = VContainer1StateVariable.Variable4.ToString(),
                    Type = typeof(string)
                },
                new UpnpStateVariable(controller, this, device)
                {
                    VariableName = VContainer1StateVariable.Variable5.ToString(),
                    Type = typeof(string)
                },
            };
        }
    }
}
