using UserLogicDiExample.Services;
using UserLogicDiExample.Services.AuthServices;

namespace UserLogicDiExample
{
    public class UserLogic
    {
        private readonly GoogleAuthService _authService;
        private readonly IEmailService _emailService;

        public UserLogic(IEmailService emailService)
        {
            _authService = new GoogleAuthService();
            _emailService = emailService; 
        }

        public void Register(string emailAddress, string password)
        {
            var authResult = _authService.Registration(emailAddress, password);
        }

        public void SendMessage(string emailAddress, string message)
        {
            _emailService.SendMail(emailAddress, message);
        }
    }
}