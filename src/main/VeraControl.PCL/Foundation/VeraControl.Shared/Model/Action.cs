using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IVeraControl.Model;

namespace VeraControl.Model
{
    internal class Action : IAction
    {
        public string ActionName { get; internal set; }
        public string ArgumentName { get; internal set; }
        public string Value { get; internal set; }
        public Direction Direction { get; internal set; }
        public Type Type { get; internal set; }
    }
}
