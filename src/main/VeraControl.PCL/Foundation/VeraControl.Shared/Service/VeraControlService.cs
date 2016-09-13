using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IVeraControl.Model;
using IVeraControl.Service;
using Newtonsoft.Json;
using VeraControl.Model;
using VeraControl.Model.Base;
using static VeraControl.Extensions.SecurityExtension;
using static VeraControl.Extensions.HelperExtensions;

namespace VeraControl.Service
{
    public class VeraControlService : DeserializeBase, IVeraControllerService
    {
        private const string PasswordSeed = "oZ7QE6LcLJp6fiWzdqZc";
        private const string PkOem = "1";
        private const string AuthenticationServer = "vera-us-oem-autha.mios.com";

        private readonly IHttpConnectionService _httpConnectionService = new HttpConnectionService();


        public async Task<IVeraControllerList> GetControllers(string username, string password)
        {
            var identityPackage = await GetIdentityPackage(username, password);

            return await GetVeraControllers(
                AuthenticationServer,
                identityPackage.IdentityDetails.PkAccount, identityPackage);
        }

        private async Task<IVeraControllerList> GetVeraControllers(string serverAuth, int pkAccount, IIdentityPackage identityPackage)
        {
            var httpRequest = $"https://{serverAuth}" +
                              $"/locator" +
                              $"/locator" +
                              $"/locator" +
                              $"?PK_Account={pkAccount}";

            var controllerList = await GetAndDeserialize<VeraControllerList>(httpRequest, _httpConnectionService);

            foreach (var controller in controllerList.VeraControllers)
            {
                controller.HttpConnectionService = _httpConnectionService;
                await controller.GetDetailsAsync(identityPackage);
            }

            return controllerList;
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

            var identityPackage = await GetAndDeserialize<IdentityPackage>(httpRequest, _httpConnectionService);

            identityPackage.Generated = identityPackage.IdentityDetails.Generated.UnixTimestampToUtcDateTime();
            identityPackage.Expires = identityPackage.IdentityDetails.Expires.UnixTimestampToUtcDateTime();

            return identityPackage;
        }
    }
}
