using System;
using System.ServiceModel;
using System.Security.Principal;
using System.Windows.Forms;
using WcfChat;

namespace ChatServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Program obj = new Program();

            if (obj.IsCurrentlyRunningAsAdmin())
                obj.RunServer();
            else
                MessageBox.Show("Did you run it as administrator?", "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void RunServer()
        {
            var host = new ServiceHost(typeof(ChatService));

            host.Open();
            Console.WriteLine("Server started");
            Console.WriteLine("\n");
            Console.WriteLine(" Configuration Name: " + host.Description.ConfigurationName);
            Console.WriteLine(" End point address: " + host.Description.Endpoints[0].Address);
            Console.WriteLine(" End point binding: " + host.Description.Endpoints[0].Binding.Name);
            Console.WriteLine(" End point contract: " + host.Description.Endpoints[0].Contract.ConfigurationName);
            Console.WriteLine(" End point name: " + host.Description.Endpoints[0].Name);
            Console.WriteLine(" End point listen uri: " + host.Description.Endpoints[0].ListenUri);
            Console.WriteLine(" \nName:" + host.Description.Name);
            Console.WriteLine(" Namespace: " + host.Description.Namespace);
            Console.WriteLine(" Service Type: " + host.Description.ServiceType);

            Console.ReadLine();
            host.Close();
        }

        private bool IsCurrentlyRunningAsAdmin()
        {
            var currentIdentity = WindowsIdentity.GetCurrent();
            var principal = new WindowsPrincipal(currentIdentity);
            var isAdmin = principal.IsInRole(WindowsBuiltInRole.Administrator);
            return isAdmin;
        }
    }
}