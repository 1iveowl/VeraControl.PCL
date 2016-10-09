using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeraControl.Model.UpnpService.Base;

namespace VeraControl.Model.UpnpService
{
    public enum TemperatureSensor1Action
    {
        GetCurrentTemperature
    }

    public enum TemperatureSensor1StateVariables
    {
        CurrentTemperature
    }
    public class TemperatureSensor1 : UpnpServiceBase
    {
        
    }
}
