using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using IVeraControl.Model;
using VeraControl.Service;
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

            var dimmer = new Dimmer1(veraPlus) {DeviceNumber = 93};

            var dimmerState = await dimmer.GetStateVariableAsync(
                ServiceType.Dimmer1,
                Dimming1StateVariable.LoadLevelStatus,
                ConnectionType.Local);

            //await Task.Delay(TimeSpan.FromSeconds(1));

            //var dimmerSwitchOff = await dimmer.ActionAsync(
            //    ServiceType.SwitchPower1,
            //    SwitchPower1Action.SetTarget,
            //    true,
            //    ConnectionType.Local);

            await Task.Delay(TimeSpan.FromSeconds(1));

            var dimmer50pct = await dimmer.ActionAsync(
                ServiceType.Dimmer1,
                Dimming1Action.SetLoadLevelTarget,
                50,
                ConnectionType.Local);

            await Task.Delay(TimeSpan.FromSeconds(1));

            var dimmer100pct = await dimmer.ActionAsync(
                ServiceType.Dimmer1,
                Dimming1Action.SetLoadLevelTarget,
                100,
                ConnectionType.Local);

            //var binaryLight = new BinaryLight1(veraPlus) {DeviceNumber = 56};

            //var binaryLightStatus = await binaryLight.GetStateVariableAsync(ServiceType.SwitchPower1, SwitchPower1StateVariable.Status, ConnectionType.Local);

            //var result = await binaryLight.ActionAsync(ServiceType.SwitchPower1, SwitchPower1Action.SetTarget, !binaryLightStatus, ConnectionType.Local);

            //var hvacTermo = new HVAC_ZoneThermostat1(veraPlus) { DeviceNumber = 528 };

            //var hvacSetResult = await hvacTermo.GetStateVariableAsync(
            //    ServiceType.TemperatureSensor1Service,
            //    TemperatureSensor1StateVariables.CurrentTemperature,
            //    ConnectionType.Local);

            //await Task.Delay(TimeSpan.FromSeconds(2));

            //await
            //    binaryLight.SetStateVariableAsync(ServiceType.SwitchPower1, SwitchPower1StateVariable.Status,
            //        binaryLightStatus, ConnectionType.Local);

        }
    }
}
