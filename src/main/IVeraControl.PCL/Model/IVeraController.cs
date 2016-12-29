using System.Threading.Tasks;
using IVeraControl.Model.Data;

namespace IVeraControl.Model
{
    public interface IVeraController : IDataVeraController
    {
        IVeraControllerDetail ControllerDetail { get; }

        Task<bool> IsAliveAsync(ConnectionType connectionType);

        Task<string> ReloadAsync(ConnectionType connectionType, bool waitUntilAliveAgain = true);

        Task<string> SendActionAsync(IUpnpDevice device, IUpnpService service, IUpnpAction action, ConnectionType connectionType);

        Task<string> VariableGetAsync(IUpnpDevice device, IUpnpService service, IUpnpStateVariable action, ConnectionType connectionType);

        Task<string> VariableSetAsync(IUpnpDevice device, IUpnpService service, IUpnpStateVariable action, ConnectionType connectionType);

        Task GetDetailsAsync();

    }
}
