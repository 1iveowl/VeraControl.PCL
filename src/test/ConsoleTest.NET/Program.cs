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

            var binaryLight = new BinaryLight1(veraPlus) {DeviceNumber = 49};

            var binaryLightStatus = await binaryLight.GetStateVariableAsync(ServiceType.SwitchPower1, SwitchStateVariable.Status, ConnectionType.Local);

            await binaryLight.ActionAsync(ServiceType.SwitchPower1, SwitchPower1Action.SetTarget, !binaryLightStatus, ConnectionType.Local);

            //var switchPower1Service = binaryLight.Services.FirstOrDefault(s => s.ServiceName == "SwitchPower1");
            //var switchPowerStateVariable = switchPower1Service?.StateVariables.FirstOrDefault(v => v.VariableName == "Status");

            //if (veraPlus != null)
            //{
            //    var getResult = await veraPlus.VariableGet(binaryLight, switchPower1Service, switchPowerStateVariable, ConnectionType.Remote);

            //    var setAction = switchPower1Service?.Actions?.FirstOrDefault(a => a.ActionName == "SetTarget");

            //    if (setAction != null)
            //    {
            //        setAction.Value = getResult == "1" ? "0" : "1";
            //        await veraPlus.SendAction(binaryLight, switchPower1Service, setAction, ConnectionType.Remote);
            //    }
            //    else
            //    {
            //        return;
            //    }
            //}

            //var vContainer = new VContainer1 {DeviceNumber = 431};
            //var vContainerService = vContainer?.Services?.FirstOrDefault(s => s.ServiceName == "VContainer1");
            //var vContainerStateVariable =
            //    vContainerService?.StateVariables?.FirstOrDefault(v => v.VariableName == "Variable1");

            //var getVariableName1 =
            //    await
            //        veraPlus.VariableGet(vContainer, vContainerService, vContainerStateVariable, ConnectionType.Remote);

            //Console.WriteLine(getVariableName1);

            //var vSwitch = new VSwitch1 {DeviceNumber = 424};
            //var vSwitchPowerService = vSwitch?.Services.FirstOrDefault(s => s.ServiceName == "SwitchPower1");
            //var vSwitchPowerStateVariable =
            //    vSwitchPowerService?.StateVariables.FirstOrDefault(v => v.VariableName == "Status");

            //var vSwitchStatus =
            //    await
            //        veraPlus.VariableGet(vSwitch, vSwitchPowerService, vSwitchPowerStateVariable, ConnectionType.Local);

            //var vSwitchAction = vSwitchPowerService?.Actions?.FirstOrDefault(a => a.ActionName == "SetTarget");

            //if (vSwitchAction != null)
            //{
            //    vSwitchAction.Value = vSwitchStatus == "1" ? "0" : "1";
            //    await veraPlus.SendAction(vSwitch, vSwitchPowerService, vSwitchAction, ConnectionType.Local);
            //}

        }
    }
}
