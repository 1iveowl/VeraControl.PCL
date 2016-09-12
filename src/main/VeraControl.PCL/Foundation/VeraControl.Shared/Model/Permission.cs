using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IVeraControl.Model;
using Newtonsoft.Json;

namespace VeraControl.Model
{
    internal class Permission : IPermission
    {
        [JsonProperty(PropertyName = "PK_Permission")]
        public int PkPermission { get; set; }

        [JsonProperty(PropertyName = "Mode")]
        public int Mode { get; set; }
    }
}
