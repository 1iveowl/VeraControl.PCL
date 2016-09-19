using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IVeraControl.Model;

namespace VeraControl.Model.UpnpDevices.Base
{
    public abstract class UpnpDeviceBase
    {
        public IEnumerable<IUpnpService> Services { get; set; }

        public virtual IUpnpService LookupService(dynamic serviceName)
        {
            return Services.FirstOrDefault(s => s.ServiceName == serviceName.ToString());
        }
    }
}
