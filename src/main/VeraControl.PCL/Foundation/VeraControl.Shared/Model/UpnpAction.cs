using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IVeraControl.Model;

namespace VeraControl.Model
{
    public class UpnpAction : IUpnpAction
    {
        private readonly IVeraController _controller;

        public string ActionName { get;  set; }
        public string ArgumentName { get; set; }
        public string Value { get; set; }
        public Direction Direction { get; set; }
        public Type Type { get; internal set; }


        public UpnpAction(IVeraController controller)
        {
            _controller = controller;
        }

        public async Task SendAction(IUpnpDevice device, IUpnpService service, ConnectionType connectionType)
        {
            await _controller.SendAction(device, service, this, connectionType);
        }
    }
}
