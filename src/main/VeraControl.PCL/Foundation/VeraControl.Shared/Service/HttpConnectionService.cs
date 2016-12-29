using System;
using System.IO;
using System.Threading.Tasks;
using IVeraControl.Service;

namespace VeraControl.Service
{
    internal class HttpConnectionService : IHttpConnectionService
    {
        public async Task<Stream> HttpGetAsync(string httpRequest, string mmsAuth = null, string mmsAuthSig = null)
        {
            throw new NotImplementedException("Not implemented in shared library. See platform specific libraries.");
        }

    }
}
