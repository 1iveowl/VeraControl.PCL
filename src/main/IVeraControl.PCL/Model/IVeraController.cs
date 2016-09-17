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

        //IHttpConnectionService HttpConnectionService { get; set; }

        IVeraControllerDetail ControllerDetail { get; }

        Task<string> SendAction(IUpnpDevice device, IUpnpService service, IUpnpAction action, ConnectionType connectionType);

        //ConnectionType CurrentConnectionType { get; }
        

        Task GetDetailsAsync();

        //Task EstablishConnection(ConnectionType connectionType = ConnectionType.Local);
    }
}
