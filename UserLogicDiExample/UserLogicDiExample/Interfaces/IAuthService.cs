namespace UserLogicDiExample.Services
{
    public interface IAuthService
    {
        bool Registration(string login, string password);
    }
}