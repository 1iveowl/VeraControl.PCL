using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Web.Http;
using IVeraControl.Service;

namespace VeraControl.Service
{
    internal class HttpConnectionService : IHttpConnectionService
    {
        public async Task<Stream> HttpGetAsync(string httpRequest, string mmsAuth = null, string mmsAuthSig = null)
        {
            if ((mmsAuth == null) && (mmsAuthSig != null))
                throw new ArgumentNullException(nameof(mmsAuth));

            if ((mmsAuth != null) && (mmsAuthSig == null))
                throw new ArgumentNullException(nameof(mmsAuthSig));

            try
            {
                using (var httpClient = new HttpClient())
                {
                    //httpClient.Timeout = TimeSpan.FromSeconds(120);

                    if (mmsAuth != null)
                    {
                        httpClient.DefaultRequestHeaders.Add("MMSAuth", mmsAuth);
                        httpClient.DefaultRequestHeaders.Add("MMSAuthSig", mmsAuthSig);
                    }

                    var inputStream = await httpClient.GetInputStreamAsync(new Uri(httpRequest));
                    return inputStream.AsStreamForRead();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
