using System;
using System.Threading.Tasks;
using IVeraControl.Model;
using static VeraControl.Helper.Helper;

namespace VeraControl.Model
{
    public class UpnpStateVariable : IUpnpStateVariable
    {
        public string VariableName { get; set; }
        public Type Type { get; set; }
        public string Value { get; set; }
        public Task<dynamic> GetStateVariable(ConnectionType connectionType)
        {
            throw new NotImplementedException(BaitNoSwitch);
        }

        public Task<string> SetStateVariable(string value, ConnectionType connection)
        {
            throw new NotImplementedException(BaitNoSwitch);
        }
    }
}
