using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IVeraControl.Model;
using IVeraControl.Model.Data;
using Newtonsoft.Json;
using VeraControl.Converter;

namespace VeraControl.Model.Json
{
    internal class JsonIdentityPackageDetail : IDataIdentityPackageDetail
    {
        [JsonProperty(PropertyName = "Expires")]
        public int Expires { get; set; }

        [JsonProperty(PropertyName = "Generated")]
        public int Generated { get; set; }

        [JsonProperty(PropertyName = "Permissions")]
        [JsonConverter(typeof(ConcreteConverter<Permission[]>))]
        public IPermission[] Permissions { get; set; }

        [JsonProperty(PropertyName = "PK_Account")]
        public int PkAccount { get; set; }

        [JsonProperty(PropertyName = "PK_AccountType")]
        public int PkAccountType { get; set; }

        [JsonProperty(PropertyName = "PK_AccountChild")]
        public int PkAccountChild { get; set; }

        [JsonProperty(PropertyName = "PK_Account_Parent")]
        public int PkAccountParent { get; set; }

        [JsonProperty(PropertyName = "PK_App")]
        public int PkApp { get; set; }

        [JsonProperty(PropertyName = "PK_Oem")]
        public int PkOem { get; set; }

        [JsonProperty(PropertyName = "PK_Oem_User")]
        public string PkOemUser { get; set; }

        [JsonProperty(PropertyName = "PK_PermissionRole")]
        public int PkPermissionRole { get; set; }

        [JsonProperty(PropertyName = "PK_User")]
        public int PkUser { get; set; }

        [JsonProperty(PropertyName = "PK_Server_Auth")]
        public int PkServerAuth { get; set; }

        [JsonProperty(PropertyName = "PK_Server_Account")]
        public int PkServerAccount { get; set; }

        [JsonProperty(PropertyName = "PK_Server_Event")]
        public int PkServerEvent { get; set; }

        [JsonProperty(PropertyName = "Server_Auth")]
        public string ServerAuth { get; set; }

        [JsonProperty(PropertyName = "Username")]
        public string Username { get; set; }
    }
}
