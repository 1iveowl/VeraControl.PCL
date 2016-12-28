using System;
using System.Linq;
using System.Threading.Tasks;
using IVeraControl.Model;
using VeraControl.Service;
using UpnpModels.Model;
using UpnpModels.Model.UpnpDevice;
using UpnpModels.Model.UpnpService;

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
            Console.Write("Username: ");
            var username = Console.ReadLine();

            Console.Write("Password: ");
            var password = Console.ReadLine();

            // Create a service
            var veraService = new VeraControlService();

            // Get all Vera Controllers in your set-up using your username and password
            var controllers = await veraService.GetControllers(username, password);

            //Pick the controller you want interact with.
            var veraPlus = controllers.FirstOrDefault(c => c.DeviceSerialId == "50102163");

            if (veraPlus == null) return;

            var aliveRemote = await veraPlus.IsAliveAsync(ConnectionType.Remote);

            var reload = await veraPlus.ReloadAsync(ConnectionType.Local);

            var aliveLocal = await veraPlus.IsAliveAsync(ConnectionType.Local);

            //var homeGateway = new HomeAutomationGateway(veraPlus);

            //var runScene = await homeGateway.ActionAsync(
            //    ServiceType.HomeAutomationGateway1,
            //    HomeAutomationGatewayAction.RunScene,
            //    77,
            //    ConnectionType.Local);

            var dimmer = new Dimmer1(veraPlus) {DeviceNumber = 93};

            var dimmerState = await dimmer.GetStateVariableAsync(
                ServiceType.Dimmer1,
                Dimming1StateVariable.LoadLevelStatus,
                ConnectionType.Local);

            await Task.Delay(TimeSpan.FromSeconds(1));

            var dimmer50Pct = await dimmer.ActionAsync(
                ServiceType.Dimmer1,
                Dimming1Action.SetLoadLevelTarget,
                50,
                ConnectionType.Local);

            await Task.Delay(TimeSpan.FromSeconds(1));

            var dimmer100Pct = await dimmer.ActionAsync(
                ServiceType.Dimmer1,
                Dimming1Action.SetLoadLevelTarget,
                100,
                ConnectionType.Local);

            //var binaryLight = new BinaryLight1(veraPlus) {DeviceNumber = 56};

            //var binaryLightStatus = await binaryLight.GetStateVariableAsync(ServiceType.SwitchPower1, SwitchPower1StateVariable.Status, ConnectionType.Local);

            //var result = await binaryLight.ActionAsync(ServiceType.SwitchPower1, SwitchPower1Action.SetTarget, !binaryLightStatus, ConnectionType.Local);

            //var thermometer = new TemperatureSensor1(veraPlus) { DeviceNumber = 528 };

            //var temperature = await thermometer.GetStateVariableAsync(
            //    ServiceType.TemperatureSensor1,
            //    TemperatureSensor1StateVariables.CurrentTemperature,
            //    ConnectionType.Local);

            //var thermostat = new HVAC_ZoneThermostat1(veraPlus) {DeviceNumber = 528};

            //var resultSetThermostate = await thermostat.ActionAsync(
            //    ServiceType.TemperatureSetpoint1,
            //    TemperatureSetpoint1Action.CurrentSetpoint,
            //    10,
            //    ConnectionType.Local);

            //await Task.Delay(TimeSpan.FromSeconds(2));

            //await
            //    binaryLight.SetStateVariableAsync(ServiceType.SwitchPower1, SwitchPower1StateVariable.Status,
            //        binaryLightStatus, ConnectionType.Local);

        }
    }
}
