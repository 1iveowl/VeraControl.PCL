using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IVeraControl.Model;
using Newtonsoft.Json;
using VeraControl.Converter;

namespace VeraControl.Model
{
    internal class VeraControllerList : IVeraControllerList
    {
        [JsonProperty(PropertyName = "Devices")]
        [JsonConverter(typeof(ConcreteConverter<List<VeraController>>))]
        public IEnumerable<IVeraController> VeraControllers { get; internal set; }
    }
}
