using System.Threading.Tasks;
using IVeraControl.Model.Data;

namespace IVeraControl.Model
{
    public interface IIdentityPackage : IDataIdentityPackage
    {
        Task GetIdentityPackage(string username, string password);
    }
}
