using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeraControl.Service;

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

            await veraService.GetControllers(username, password);
        }
    }
}
