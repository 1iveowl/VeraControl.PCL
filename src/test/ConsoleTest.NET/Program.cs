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

            var binaryLight = new BinaryLight1();
            var switchPower = binaryLight.Services.FirstOrDefault(s => s.ServiceName == "SwitchPower1");
            var action = switchPower?.Actions?.FirstOrDefault(a => a.ActionName == "SetTarget");

            binaryLight.DeviceNumber = "56";

            if (action != null)
            {
                action.Value = "1";
            }
            else
            {
                return;
            }
            

            if (veraPlus != null)
            {
                var result = await veraPlus.SendAction(binaryLight, switchPower, action, ConnectionType.Remote);
            }
            
        }
    }
}
