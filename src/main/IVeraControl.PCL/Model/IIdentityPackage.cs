using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IVeraControl.Model.Data;

namespace IVeraControl.Model
{
    public interface IIdentityPackage : IDataIdentityPackage
    {
        Task GetIdentityPackage(string username, string password);

        //Task GetIdentityPackageDetails();
    }
}
