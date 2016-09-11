using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IVeraControl.Model;
using IVeraControl.Service;
using VeraControl.Model;

namespace VeraControl.Service
{
    public class VeraControlService : IVeraControllerService
    {
        private const string PasswordSeed = "oZ7QE6LcLJp6fiWzdqZc";
        private const string PkOem = "1";
        private const string AuthenticationServer = "vera-us-oem-autha.mios.com";

        private IVeraControllerList _veraControllerList = new VeraControllerList();

        public Task<IVeraControllerList> GetControllers(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
