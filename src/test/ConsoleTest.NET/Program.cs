using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
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

            //var binaryLight = new BinaryLight1(veraPlus) {DeviceNumber = 56};

            //var binaryLightStatus = await binaryLight.GetStateVariableAsync(ServiceType.SwitchPower1, SwitchPower1StateVariable.Status, ConnectionType.Local);

            //var result = await binaryLight.ActionAsync(ServiceType.SwitchPower1, SwitchPower1Action.SetTarget, !binaryLightStatus, ConnectionType.Local);

            var temperatureSensor = new TemperatureSensor1(veraPlus) {DeviceNumber = 451};

            var temperature = await temperatureSensor.GetStateVariableAsync(
                ServiceType.TemperatureSensor1Service,
                TemperatureSensor1StateVariables.CurrentTemperature,
                ConnectionType.Local);

            await Task.Delay(TimeSpan.FromSeconds(2));

            //await
            //    binaryLight.SetStateVariableAsync(ServiceType.SwitchPower1, SwitchPower1StateVariable.Status,
            //        binaryLightStatus, ConnectionType.Local);

        }
    }
}
