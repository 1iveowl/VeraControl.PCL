using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IVeraControl.Model;
using IVeraControl.Service;
using Newtonsoft.Json;
using VeraControl.Model;
using static VeraControl.Extensions.SecurityExtension;
using static VeraControl.Extensions.HelperExtensions;

namespace VeraControl.Service
{
    public class VeraControlService : IVeraControllerService
    {
        private const string PasswordSeed = "oZ7QE6LcLJp6fiWzdqZc";
        private const string PkOem = "1";
        private const string AuthenticationServer = "vera-us-oem-autha.mios.com";

        private readonly IHttpConnectionService _httpConnectionService = new HttpConnectionService();

        //private IdentityPackage _identityPackage;

        private IVeraControllerList _veraControllerList = new VeraControllerList();

        public async Task<IVeraControllerList> GetControllers(string username, string password)
        {
            var identityPackage = await GetIdentityPackage(username, password);

            return await GetVeraControllers(
                identityPackage.IdentityDetails.ServerAuth,
                identityPackage.IdentityDetails.PkAccount);
        }

        private async Task<IVeraControllerList> GetVeraControllers(string serverAuth, int pkAccount)
        {
            var httpRequest = $"https://{serverAuth}" +
                              $"/locator" +
                              $"/locator" +
                              $"/locator" +
                              $"?PK_Account={pkAccount}";

            return await GetAndDeserialize<IVeraControllerList>(httpRequest);

        }

        private async Task<IIdentityPackage> GetIdentityPackage(string username, string password)
        {
            var passwordhash = $"{username}{password}{PasswordSeed}".Sha1Hash();

            var httpRequest = $"https://{AuthenticationServer}" +
                              $"/autha" +
                              $"/auth" +
                              $"/username" +
                              $"/{username}" +
                              $"?SHA1Password={passwordhash}" +
                              $"&PK_Oem={PkOem}";

            var identityPackage = await GetAndDeserialize<IdentityPackage>(httpRequest);

            identityPackage.Generated = identityPackage.IdentityDetails.Generated.UnixTimestampToUtcDateTime();
            identityPackage.Expires = identityPackage.IdentityDetails.Expires.UnixTimestampToUtcDateTime();

            return identityPackage;
        }

        private async Task<T> GetAndDeserialize<T>(string httpRequest)
        {
            try
            {
                var stream = await _httpConnectionService.HttpGetAsync(httpRequest);

                using (var sr = new StreamReader(stream))
                using (var reader = new JsonTextReader(sr))
                {
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
