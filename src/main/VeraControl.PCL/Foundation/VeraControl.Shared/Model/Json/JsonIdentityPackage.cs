using System;
using System.Text;
using IVeraControl.Model;
using IVeraControl.Model.Data;
using Newtonsoft.Json;
using VeraControl.Extensions;

namespace VeraControl.Model.Json
{
    internal class JsonIdentityPackage : IDataIdentityPackage
    {
        private string _identityBase64;

        [JsonProperty(PropertyName = "Identity")]

        public string IdentityBase64
        {
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
                IdentityDetails = JsonConvert.DeserializeObject<IdentityPackageDetail>(_identityText);
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

        public DateTime Generated => IdentityDetails.Generated.UnixTimestampToUtcDateTime();
        public DateTime Expires => IdentityDetails.Expires.UnixTimestampToUtcDateTime();

        public bool IsStale => Expires < DateTime.UtcNow;


        private static string ConvertBase64StringToUtf8(string str)
        {
            var bArray = Convert.FromBase64String(str);
            var len = bArray.Length;
            return Encoding.UTF8.GetString(bArray, 0, len);
        }
    }
}
