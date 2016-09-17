using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using IVeraControl.Model;
using VeraControl.Model.UpnpDevices;
using VeraControl.Service;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Test.UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Go_OnClick(object sender, RoutedEventArgs e)
        {
            Start();
        }

        private async Task Start()

        {
            var veraService = new VeraControlService();

            var controllers = await veraService.GetControllers(
                Username.Text,
                Password.Text);

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
