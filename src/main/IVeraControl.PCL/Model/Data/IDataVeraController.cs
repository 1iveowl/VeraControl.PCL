using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IVeraControl.Model.Data
{
    public interface IDataVeraController
    {
        string DeviceSerialId { get; }

        string MacAddress { get; }

        int PkDeviceType { get; }

        int PkDeviceSubType { get; }

        string ServerDevice { get; }

        string ServerEvent { get; }

        int PkAccount { get; }

        string ServerAccount { get; }

        string LocalIpAddress { get; }

        string LastAliveReported { get; }

        //bool ConnectionEstablished { get; }

    }
}
