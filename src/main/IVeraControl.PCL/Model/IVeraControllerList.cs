using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace IVeraControl.Model
{
    public interface IVeraControllerList
    {
        
        IEnumerable<IVeraController> VeraControllers { get; }

        //Task<IEnumerable<IVeraController>> GetControllerList(string username, string password);
    }
}
