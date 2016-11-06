using System.Collections.Generic;

namespace IVeraControl.Model
{
    public interface IVeraControllerList
    {
        
        IEnumerable<IVeraController> VeraControllers { get; }
    }
}
