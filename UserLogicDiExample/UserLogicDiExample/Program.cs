using System;
using Common;
using UserLogicDiExample.Services;
using UserLogicDiExample.Services.EmailServices;

namespace UserLogicDiExample
{
    internal class Program
    {
        private static UserLogic _userLogic;

        private static void Main()
        {
            _userLogic = new UserLogic(EmailServiceInit());
            SendMessage();
            Console.ReadKey();
        }

        private static void SendMessage()
        {
            Console.Write("\nEnter your message - ");
            var message = Console.ReadLine();
            Console.Write("Enter recipient - ");
            var recipient = Console.ReadLine();
            _userLogic.SendMessage(recipient, message);
        }

        private static IEmailService EmailServiceInit()
        {
            var body = new[]
            {
                "What service do you want to use:",
                "Google",
                "OutLook"
            };
            var choose = Menu.CreateMenuIntWithoutEsc(body);
            switch (choose)
            {
                case 1:
                    return new GoogleEmailService();
                default:
                    return new OutlookEmailService();
            }
        }
    }
}
