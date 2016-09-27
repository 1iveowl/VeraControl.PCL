using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using IVeraControl.Service;
using Newtonsoft.Json;

namespace VeraControl.Helper
{
    internal class HttpGetDeserializer
    {
        internal async Task<T> GetAndDeserialize<T>(
            string httpRequest,
            IHttpConnectionService httpConnectionService,
            string mmsAuth = null,
            string mmsAuthSig = null)
        {
            try
            {
                var stream = await httpConnectionService.HttpGetAsync(httpRequest, mmsAuth, mmsAuthSig);

                using (var sr = new StreamReader(stream))
                using (var reader = new JsonTextReader(sr))
                {

#if DEBUG && !WINDOWS_UWP
                    var debugStreamToText = sr.ReadToEnd();
                    Debug.WriteLine(debugStreamToText);
                    stream.Position = 0;
#endif
                    var serializer = new JsonSerializer();
                    var obj = serializer.Deserialize<T>(reader);
                    return obj;

                }
            }
            catch (Exception ex)
            {
                throw new AggregateException("Unable to deserialize data.", ex);
            }

        }

        internal async Task<string> GetString(
            string httpRequest,
            IHttpConnectionService httpConnectionService,
            string mmsAuth = null,
            string mmsAuthSig = null)
        {
            try
            {
                var stream = await httpConnectionService.HttpGetAsync(httpRequest, mmsAuth, mmsAuthSig);

                using (var sr = new StreamReader(stream))
                {
                    return sr.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
