using System;

namespace Log4Net
{
    internal class Program
    {
        private static void Main()
        {
            Logger.InitLogger();

            Logger.Log.Info("Ура заработало!");

            Console.ReadKey();
        }
    }
}
