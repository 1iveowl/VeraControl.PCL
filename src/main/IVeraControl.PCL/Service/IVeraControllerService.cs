using System.Collections.Generic;
using System.Threading.Tasks;
using IVeraControl.Model;

namespace IVeraControl.Service
{
    public interface IVeraControllerService
    {
        Task<IEnumerable<IVeraController>> GetControllers(string username, string password);
    }
}
