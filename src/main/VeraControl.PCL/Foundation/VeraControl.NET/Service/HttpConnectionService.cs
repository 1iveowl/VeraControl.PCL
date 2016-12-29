using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
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

            Stream stream;

            try
            {
                HttpClientHandler handler = new HttpClientHandler()
                {
                    AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
                };


                using (var httpClient = new HttpClient(handler))
                using (var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, new Uri(httpRequest)))
                {
                    //httpClient.Timeout = TimeSpan.FromSeconds(30);

                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("*/*"));
                    httpClient.DefaultRequestHeaders.AcceptLanguage.Add(StringWithQualityHeaderValue.Parse("en-us"));
                    httpClient.DefaultRequestHeaders.AcceptEncoding.Add(StringWithQualityHeaderValue.Parse("gzip"));
                    httpClient.DefaultRequestHeaders.AcceptEncoding.Add(StringWithQualityHeaderValue.Parse("deflate"));
                    httpClient.DefaultRequestHeaders.Connection.Add("Keep-Alive");
                    httpClient.DefaultRequestHeaders.UserAgent.Add(ProductInfoHeaderValue.Parse("VeraControl.PCL"));
                    if (mmsAuth != null)
                    {
                        httpClient.DefaultRequestHeaders.Add("MMSAuth", mmsAuth);
                        httpClient.DefaultRequestHeaders.Add("MMSAuthSig", mmsAuthSig);
                    }

                    var responseMessage = await httpClient.SendAsync(httpRequestMessage).ConfigureAwait(false);

                    stream = await responseMessage.Content.ReadAsStreamAsync().ConfigureAwait(false);

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
