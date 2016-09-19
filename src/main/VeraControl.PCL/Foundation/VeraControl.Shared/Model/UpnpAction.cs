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
        private readonly IUpnpService _service;
        private readonly IUpnpDevice _device;

        public string ActionName { get;  set; }
        public string ArgumentName { get; set; }
        public string Value { get; set; }
        public Direction Direction { get; set; }
        public Type Type { get; internal set; }


        public UpnpAction(IVeraController controller, IUpnpService service, IUpnpDevice device)
        {
            _controller = controller;
            _service = service;
            _device = device;
        }

        public async Task SendAction(ConnectionType connectionType)
        {
            await _controller.SendAction(_device, _service, this, connectionType);
        }
    }
}
