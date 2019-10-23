using System;
using System.ServiceModel;

namespace MathServiceHost
{
    internal class Program
    {
        private static void Main()
        {
            var host = new ServiceHost(typeof(MathService.MathService));
            host.Open();
            Console.WriteLine("Service Hosted Successfully");
            Console.ReadKey();
        }
    }
}
