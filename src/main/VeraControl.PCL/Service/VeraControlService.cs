using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IVeraControl.Model;
using IVeraControl.Service;
using static VeraControl.Helper.Helper;

namespace VeraControl.Service
{
    public class VeraControlService : IVeraControllerService
    {
        public Task<IEnumerable<IVeraController>> GetControllers(string username, string password)
        {
            throw new NotImplementedException(BaitNoSwitch);
        }
    }
}
