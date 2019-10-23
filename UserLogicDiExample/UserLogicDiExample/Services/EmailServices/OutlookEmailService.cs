using System;

namespace UserLogicDiExample.Services.EmailServices
{
    public class OutlookEmailService : IEmailService
    {
        public void SendMail(string emailAddress, string message)
        {
            Console.WriteLine("\nSend message using Google");
        }
    }
}