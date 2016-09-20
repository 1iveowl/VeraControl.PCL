using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IVeraControl.Model;
using static VeraControl.Helper.Helper;

namespace VeraControl.Model
{
    public class UpnpAction : IUpnpAction
    {
        public string ActionName => null;
        public string ArgumentName { get; set; }
        public string Value { get; set; }
        public Direction Direction { get; }
        public Type Type => null;
        public Task<dynamic> SendAction(ConnectionType connectionType)
        {
            throw new NotImplementedException(BaitNoSwitch);
        }
    }
}
