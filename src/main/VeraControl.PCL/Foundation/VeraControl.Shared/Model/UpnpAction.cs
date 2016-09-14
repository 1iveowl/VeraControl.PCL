using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IVeraControl.Model;

namespace VeraControl.Model
{
    public class UpnpAction : IUpnpAction
    {
        public string ActionName { get;  set; }
        public string ArgumentName { get; set; }
        public string Value { get; set; }
        public Direction Direction { get; set; }
        public Type Type { get; internal set; }
    }
}
