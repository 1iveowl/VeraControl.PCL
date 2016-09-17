using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using IVeraControl.Model;
using IVeraControl.Service;
using Newtonsoft.Json;
using VeraControl.Helper;
using VeraControl.Model;
using VeraControl.Model.Json;
using static VeraControl.Extensions.SecurityExtension;
using static VeraControl.Extensions.HelperExtensions;

namespace VeraControl.Service
{
    public class VeraControlService : IVeraControllerService
    {
        private const string PasswordSeed = "oZ7QE6LcLJp6fiWzdqZc";
        private const string PkOem = "1";
        private const string AuthenticationServer = "vera-us-oem-autha.mios.com";

        private readonly HttpGetDeserializer _httpDeserializer = new HttpGetDeserializer();

        private readonly IHttpConnectionService _httpConnectionService = new HttpConnectionService();

        private readonly IMapper _mapper;

        private IIdentityPackage _identityPackage;

        public VeraControlService()
        {
            // Initialize AutoMapper
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<JsonVeraController, VeraController>().ConstructUsing(x => new VeraController(_httpConnectionService, _identityPackage));
                cfg.CreateMap<JsonVeraConrtollerDetail, VeraControllerDetail>();
            });

            _mapper = config.CreateMapper();
        }


        public async Task<IEnumerable<IVeraController>> GetControllers(string username, string password)
        {
            _identityPackage = await GetIdentityPackage(username, password);

            return await GetVeraControllers(
                AuthenticationServer,
                _identityPackage.IdentityDetails.PkAccount, _identityPackage);
        }

        private async Task<IEnumerable<IVeraController>> GetVeraControllers(string serverAuth, int pkAccount, IIdentityPackage identityPackage)
        {
            var httpRequest = $"https://{serverAuth}" +
                              $"/locator" +
                              $"/locator" +
                              $"/locator" +
                              $"?PK_Account={pkAccount}";

            // Get Controller Data
            var controllerDataList = await _httpDeserializer.GetAndDeserialize<JsonVeraControllerList>(httpRequest, _httpConnectionService);

            // Map data to model object and inject IdentityData and HttpConnectionService
            var veraControllerList = new List<VeraController>();
            foreach (var controllerData in controllerDataList.VeraControllers)
            {
                var veraController = _mapper.Map<JsonVeraController, VeraController>(controllerData);
                await veraController.GetDetailsAsync();

                veraControllerList.Add(veraController);
            }

            return veraControllerList;
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

            var identityPackage = await _httpDeserializer.GetAndDeserialize<IdentityPackage>(httpRequest, _httpConnectionService);

            identityPackage.Generated = identityPackage.IdentityDetails.Generated.UnixTimestampToUtcDateTime();
            identityPackage.Expires = identityPackage.IdentityDetails.Expires.UnixTimestampToUtcDateTime();

            return identityPackage;
        }
    }
}
