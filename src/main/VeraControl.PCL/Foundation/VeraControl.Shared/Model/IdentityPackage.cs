using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IVeraControl.Model;

namespace VeraControl.Model
{
    internal class IdentityPackage : IIdentityPackage
    {
        public string IdentityBase64 { get; }
        public string IdentityText { get; }
        public IIdentityDetails IdentityDetails { get; }
        public string IdentitySignature { get; }
        public string EventServer { get; }
        public string EventServerAlt { get; }
        public string AccountServer { get; }
        public string AccountServerAlt { get; }
        public DateTime Generated { get; }
        public DateTime Expires { get; }
        public bool IsStale => Expires < DateTime.UtcNow;

        public Task GetIdentityPackage(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
