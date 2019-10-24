using WpfMessengerApp.Recources;

namespace WpfMessengerApp.Services
{
    public class MainLocalizationService : IMainLocalizationService
    {
        public void Localize()
        {
            MainTitle = MainEnLocalization.MainTitle;
        }

        public string MainTitle { get; set; }
    }
}
