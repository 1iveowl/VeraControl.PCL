using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using IVeraControl.Model;
using IVeraControl.Service;
using VeraControl.Helper;
using VeraControl.Model;
using VeraControl.Model.Json;

namespace VeraControl.Service
{
    public class VeraControlService : IVeraControllerService
    {
        private const string AuthenticationServer = "vera-us-oem-autha.mios.com";

        private readonly HttpGetDeserializer _httpDeserializer = new HttpGetDeserializer();
        private readonly IHttpConnectionService _httpConnectionService = new HttpConnectionService();
        private readonly IIdentityPackage _identityPackage;
        private readonly IMapper _mapper;
        private string _username;
        private string _password;

        public VeraControlService()
        {
            // Initialize AutoMapper
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<JsonVeraController, VeraController>().ConstructUsing(x => new VeraController(_httpConnectionService, _identityPackage, _username, _password));
            });

            _mapper = config.CreateMapper();

            _identityPackage = new IdentityPackage(_httpConnectionService, AuthenticationServer);
        }

        public async Task<IEnumerable<IVeraController>> GetControllers(string username, string password)
        {
            _username = username;
            _password = password;

            await _identityPackage.GetIdentityPackage(_username, _password);

            var httpRequest = $"https://{AuthenticationServer}" +
                              $"/locator" +
                              $"/locator" +
                              $"/locator" +
                              $"?PK_Account={_identityPackage.IdentityDetails.PkAccount}";

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
    }
}
