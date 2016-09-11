using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IVeraControl.Model;

namespace VeraControl.Model
{
    internal class VeraControllerList : IVeraControllerList
    {
        public IEnumerable<IVeraController> VeraControllers { get; internal set; }
    }
}
