using System;

namespace UserLogicDiExample.Services.EmailServices
{
    public class GoogleEmailService : IEmailService
    {
        public void SendMail(string emailAddress, string message)
        {
            Console.WriteLine("\nSent message using Outlook");
        }
    }
}