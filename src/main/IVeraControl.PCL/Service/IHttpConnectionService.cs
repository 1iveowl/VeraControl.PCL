using System.IO;
using System.Threading.Tasks;

namespace IVeraControl.Service
{
    public interface IHttpConnectionService
    {
        Task<Stream> HttpGetAsync(string httpRequest, string mmsAuth = null, string mmsAuthSig = null);
    }
}
