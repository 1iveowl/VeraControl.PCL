using System;
using VeraControl.Extensions;
using VeraControl.Helper;
using VeraControl.Model.Json;

namespace VeraControl.Model.UpnpService
{
    //Specification: http://upnp.org/specs/ha/UPnP-ha-SwitchPower-v1-Service.pdf

    using System.Threading.Tasks;
    using AutoMapper;
    using IVeraControl.Model;
    using IVeraControl.Service;

    namespace VeraControl.Model
    {
        internal class IdentityPackage : JsonIdentityPackage, IIdentityPackage
        {
            private const string PasswordSeed = "oZ7QE6LcLJp6fiWzdqZc";
            private const string PkOem = "1";
            private readonly string _authenticationServer;

            private readonly IMapper _mapper;

            private readonly HttpGetDeserializer _httpDeserializer = new HttpGetDeserializer();

            private readonly IHttpConnectionService _httpConnectionService;

            internal IdentityPackage(IHttpConnectionService httpConnectionService, string authenticationServer)
            {
                _httpConnectionService = httpConnectionService;
                _authenticationServer = authenticationServer;

                // Initialize AutoMapper
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<JsonIdentityPackage, IdentityPackage>();
                });

                _mapper = config.CreateMapper();
            }

            public async Task GetIdentityPackage(string username, string password)
            {
                var passwordhash = $"{username}{password}{PasswordSeed}".Sha1Hash();

                var httpRequest = $"https://{_authenticationServer}" +
                                  $"/autha" +
                                  $"/auth" +
                                  $"/username" +
                                  $"/{username}" +
                                  $"?SHA1Password={passwordhash}" +
                                  $"&PK_Oem={PkOem}";
                try
                {
                    var identityDataPackage =
                        await
                            _httpDeserializer.GetAndDeserialize<JsonIdentityPackage>(httpRequest, _httpConnectionService);
                    _mapper.Map(identityDataPackage, this);
                }
                catch (Exception ex)
                {

                    throw new AggregateException("Unable to obtain Identity Package. Was username/password correct?", ex);
                }
            }

        }
    }
}
