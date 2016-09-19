using System;
using System.Threading.Tasks;
using VeraControl.Model;

namespace IVeraControl.Model
{
    public interface IUpnpAction
    {
        string ActionName { get; }
        string ArgumentName { get; set; }
        string Value { get; set; }
        Direction Direction { get; }
        Type Type { get;  }

        Task SendAction(IUpnpDevice device, IUpnpService service, ConnectionType connectionType);
    }
}
