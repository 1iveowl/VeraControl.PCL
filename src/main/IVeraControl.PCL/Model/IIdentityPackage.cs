using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IVeraControl.Model
{
    public interface IIdentityPackage
    {
        string IdentityBase64 { get; }

        string IdentityText { get; }

        IIdentityDetails IdentityDetails { get; }

        string IdentitySignature { get; }

        string EventServer { get; }

        string EventServerAlt { get; }

        string AccountServer { get; }

        string AccountServerAlt { get; }

        DateTime Generated { get; }

        DateTime Expires { get;}

        bool IsStale { get; }

        //Task GetIdentityPackage(string username, string password);
    }
}
