using System.Threading.Tasks;
using IVeraControl.Model;

namespace IVeraControl.Service
{
    public interface IVeraControllerService
    {
        Task<IVeraControllerList> GetControllers(string username, string password);
    }
}
