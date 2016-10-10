using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IVeraControl.Model;

namespace VeraControl.Model
{
    public class UpnpStateVariable : IUpnpStateVariable
    {
        private readonly IVeraController _controller;
        private readonly IUpnpService _service;
        private readonly IUpnpDevice _device;

        public string VariableName { get; set; }
        public Type Type { get; set; }

        public string Value { get; set; }
        

        public UpnpStateVariable(IVeraController controller, IUpnpService service, IUpnpDevice device)
        {
            _controller = controller;
            _service = service;
            _device = device;
        }

        public async Task<dynamic> GetStateVariable(ConnectionType connectionType)
        {
            return await _controller.VariableGetAsync(_device, _service, this, connectionType);
        }

        public async Task<string> SetStateVariable(string value, ConnectionType connection)
        {
            Value = value;
            return await _controller.VariableSetAsync(_device, _service, this, connection);
        }
    }
}
