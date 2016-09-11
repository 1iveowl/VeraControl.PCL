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
        private IVeraControllerList _veraControllerList = new VeraControllerList();

        public Task<IVeraControllerList> GetControllers(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
