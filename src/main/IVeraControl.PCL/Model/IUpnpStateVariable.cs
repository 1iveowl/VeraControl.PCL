using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IVeraControl.Model
{
    public interface IUpnpStateVariable
    {
        string VariableName { get; set; }
        Type Type { get; set; }
        string Value { get; set; }
    }
}
