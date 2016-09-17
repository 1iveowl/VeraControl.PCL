using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IVeraControl.Model;
using VeraControl.Service;
using VeraControl.Model;
using VeraControl.Model.UpnpDevices;
using VeraControl.Model.UpnpService;

namespace ConsoleTest.NET
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Start();
            Console.ReadLine();

        }

        private static async void Start()
        {
            var veraService = new VeraControlService();

            Console.Write("Username: ");
            var username = Console.ReadLine();

            Console.Write("Password: ");
            var password = Console.ReadLine();

            var controllers = await veraService.GetControllers(username, password);

            var veraPlus = controllers.FirstOrDefault(c => c.DeviceSerialId == "50102163");

            var binaryLight = new BinaryLight1 {DeviceNumber = "56"};

            var switchPower = binaryLight.Services.FirstOrDefault(s => s.ServiceName == "SwitchPower1");
            var switchPowerStateVariable = switchPower?.StateVariables.FirstOrDefault(v => v.VariableName == "Status");


            var getAction = switchPower?.Actions?.FirstOrDefault(a => a.ActionName == "GetTarget");


            if (veraPlus != null)
            {
                //var getResult = await veraPlus.SendAction(binaryLight, switchPower, getAction, ConnectionType.Remote);
                var getResult = await veraPlus.VariableGet(binaryLight, switchPower, switchPowerStateVariable, ConnectionType.Remote);

                var setAction = switchPower?.Actions?.FirstOrDefault(a => a.ActionName == "SetTarget");

                

                if (setAction != null)
                {
                    setAction.Value = "1";
                }
                else
                {
                    return;
                }

            }
            
        }
    }
}
