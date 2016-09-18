using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IVeraControl.Model;

namespace VeraControl.Model
{
    public class UpnpStateVariable : IUpnpStateVariable
    {
        public string VariableName { get; set; }
        public Type Type { get; set; }

        public string Value { get; set; }
    }
}
