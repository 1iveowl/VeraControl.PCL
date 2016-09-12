using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IVeraControl.Service;
using Newtonsoft.Json;

namespace VeraControl.Model.Base
{
    public class DeserializeBase
    {
        protected async Task<T> GetAndDeserialize<T>(
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

#if DEBUG
                    var debugStreamToText = sr.ReadToEnd();
                    Debug.WriteLine(debugStreamToText);
                    stream.Position = 0;
#endif

                    var serializer = new JsonSerializer();
                    var obj = serializer.Deserialize<T>(reader);


                    return obj;
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
