namespace UserLogicDiExample.Services
{
    public interface IEmailService
    {
        void SendMail(string emailAddress, string message);
    }
}