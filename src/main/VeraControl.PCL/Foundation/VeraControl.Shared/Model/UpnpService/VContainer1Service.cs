using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IVeraControl.Model;

namespace VeraControl.Model.UpnpService
{
    public class VContainer1Service : IUpnpService
    {
        public string ServiceUrn => "urn:upnp-org:serviceId:VContainer1";
        public string ServiceName => "VContainer1";
        public IEnumerable<IUpnpAction> Actions { get; set; } = null;
        public IEnumerable<IUpnpStateVariable> StateVariables { get; set; } = new List<UpnpStateVariable>
        {
            new UpnpStateVariable
            {
                VariableName = "VariableName1",
                Type = typeof(string)
            },
            new UpnpStateVariable
            {
                VariableName = "VariableName2",
                Type = typeof(string)
            },
            new UpnpStateVariable
            {
                VariableName = "VariableName3",
                Type = typeof(string)
            },
            new UpnpStateVariable
            {
                VariableName = "VariableName4",
                Type = typeof(string)
            },
            new UpnpStateVariable
            {
                VariableName = "Variable1",
                Type = typeof(string)
            },
            new UpnpStateVariable
            {
                VariableName = "Variable2",
                Type = typeof(string)
            },
            new UpnpStateVariable
            {
                VariableName = "Variable3",
                Type = typeof(string)
            },
            new UpnpStateVariable
            {
                VariableName = "Variable4",
                Type = typeof(string)
            },
        };
    }
}
