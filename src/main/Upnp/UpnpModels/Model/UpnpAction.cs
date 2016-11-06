using System;
using System.Threading.Tasks;
using IVeraControl.Model;

namespace UpnpModels.Model
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

        public async Task<dynamic> SendAction(ConnectionType connectionType)
        {
            var result = await _controller.SendActionAsync(_device, _service, this, connectionType);

            return result;
        }
    }
}
