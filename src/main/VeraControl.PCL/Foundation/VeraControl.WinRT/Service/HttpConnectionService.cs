using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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
                    var cts = new CancellationTokenSource(TimeSpan.FromSeconds(30));

                    if (mmsAuth != null)
                    {
                        httpClient.DefaultRequestHeaders.Add("MMSAuth", mmsAuth);
                        httpClient.DefaultRequestHeaders.Add("MMSAuthSig", mmsAuthSig);
                    }

                    var responseMessage = await httpClient.SendRequestAsync(httpRequestMessage).AsTask(cts.Token).ConfigureAwait(false);

                    var inputStream = await responseMessage.Content.ReadAsInputStreamAsync();

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
