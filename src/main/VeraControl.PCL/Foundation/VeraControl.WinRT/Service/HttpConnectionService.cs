using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage.Streams;
using Windows.Web.Http;
using IVeraControl.Service;

namespace VeraControl.Service
{
    // TODO Implement timeout using CancellationToken
    internal class HttpConnectionService : IHttpConnectionService
    {
        public async Task<Stream> HttpGetAsync(string httpRequest, string mmsAuth = null, string mmsAuthSig = null)
        {
            

            if ((mmsAuth == null) && (mmsAuthSig != null))
                throw new ArgumentNullException(nameof(mmsAuth));

            if ((mmsAuth != null) && (mmsAuthSig == null))
                throw new ArgumentNullException(nameof(mmsAuthSig));

            Stream stream;

            try
            {
                using (var httpClient = new HttpClient())
                using (var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, new Uri(httpRequest)))
                {
                    //httpClient.Timeout = TimeSpan.FromSeconds(120);

                    if (mmsAuth != null)
                    {
                        httpClient.DefaultRequestHeaders.Add("MMSAuth", mmsAuth);
                        httpClient.DefaultRequestHeaders.Add("MMSAuthSig", mmsAuthSig);
                    }

                    var responseMessage = await httpClient.SendRequestAsync(httpRequestMessage);

                    var inputStream = await responseMessage.Content.ReadAsInputStreamAsync();

                    //var inputStream = await httpClient.GetInputStreamAsync(new Uri(httpRequest));
                    stream = inputStream.AsStreamForRead();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return stream;
        }
    }
}
