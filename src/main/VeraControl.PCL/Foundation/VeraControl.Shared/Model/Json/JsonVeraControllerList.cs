using System.Collections.Generic;
using Newtonsoft.Json;
using VeraControl.Converter;

namespace VeraControl.Model.Json
{
    internal class JsonVeraControllerList
    {
        [JsonProperty(PropertyName = "Devices")]
        [JsonConverter(typeof(ConcreteConverter<List<VeraController>>))]
        public IEnumerable<JsonVeraController> VeraControllers { get; internal set; }
    }
}
