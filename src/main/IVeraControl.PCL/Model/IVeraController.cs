using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IVeraControl.Service;

namespace IVeraControl.Model
{
    public interface IVeraController
    {
        string DeviceSerialId { get; }

        string MacAddress { get; }

        int PkDeviceType { get; }

        int PkDeviceSubType { get; }

        string ServerDevice { get; }

        string ServerEvent { get; }

        int PkAccount { get; }

        string ServerAccount { get; }

        string LocalIpAddress { get; }

        string LastAliveReported { get; }

        //bool ConnectionEstablished { get; }

        IHttpConnectionService HttpConnectionService { get; set; }

        IVeraControllerDetail ControllerDetail { get; }

        Task<string> SendAction(IUpnpDevice device, IUpnpService service, string value, ConnectionType connectionType);

        //ConnectionType CurrentConnectionType { get; }
        

        Task GetDetailsAsync(IIdentityPackage identityPackage);

        //Task EstablishConnection(ConnectionType connectionType = ConnectionType.Local);
    }
}
