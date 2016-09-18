using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IVeraControl.Model.Data;
using IVeraControl.Service;

namespace IVeraControl.Model
{
    public interface IVeraController : IDataVeraController
    {
        IVeraControllerDetail ControllerDetail { get; }

        Task<string> SendAction(IUpnpDevice device, IUpnpService service, IUpnpAction action, ConnectionType connectionType);

        Task<string> VariableGet(IUpnpDevice device, IUpnpService service, IUpnpStateVariable action, ConnectionType connectionType);

        Task<string> VariableSet(IUpnpDevice device, IUpnpService service, IUpnpStateVariable action, ConnectionType connectionType);

        Task GetDetailsAsync();

    }
}
