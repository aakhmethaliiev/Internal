namespace WpfMessengerApp.Services
{
    public interface IMainLocalizationService
    {
        void Localize();
        string MainTitle { get; set; }
    }
}
