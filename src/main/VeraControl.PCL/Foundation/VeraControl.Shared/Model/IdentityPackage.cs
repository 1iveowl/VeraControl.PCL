using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IVeraControl.Model;
using IVeraControl.Service;
using Newtonsoft.Json;

namespace VeraControl.Model
{
    internal class IdentityPackage : IIdentityPackage
    {
        //private IHttpConnectionService _httpConnectionService;
        
        private string _identityBase64;

        [JsonProperty(PropertyName = "Identity")]
        
        public string IdentityBase64 {
            get
            {
                return _identityBase64;
            }
            internal set
            {
                _identityBase64 = value;
                IdentityText = ConvertBase64StringToUtf8(_identityBase64);
            }
        }

        private string _identityText;

        public string IdentityText
        {
            get
            {
                return _identityText;
            }
            private set
            {
                _identityText = value;
                IdentityDetails = JsonConvert.DeserializeObject<IdentityDetail>(_identityText);
            }
        }

        public IIdentityDetails IdentityDetails { get; private set; }

        [JsonProperty(PropertyName = "IdentitySignature")]
        public string IdentitySignature { get; internal set; }

        [JsonProperty(PropertyName = "Server_Event")]
        public string EventServer { get; internal set; }

        [JsonProperty(PropertyName = "Server_Event_Alt")]
        public string EventServerAlt { get; internal set; }

        [JsonProperty(PropertyName = "Server_Account")]
        public string AccountServer { get; internal set; }

        [JsonProperty(PropertyName = "Server_Account_Alt")]
        public string AccountServerAlt { get; internal set; }

        public DateTime Generated { get; internal set; }
        public DateTime Expires { get; internal set; }

        public bool IsStale => Expires < DateTime.UtcNow;

        private static string ConvertBase64StringToUtf8(string str)
        {
            var bArray = Convert.FromBase64String(str);
            var len = bArray.Length;
            return Encoding.UTF8.GetString(bArray, 0, len);
        }

        //internal IdentityPackage(IHttpConnectionService httpConnectionService)
        //{
        //    _httpConnectionService = httpConnectionService;
        //}

        //public Task GetIdentityPackage(string username, string password)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
