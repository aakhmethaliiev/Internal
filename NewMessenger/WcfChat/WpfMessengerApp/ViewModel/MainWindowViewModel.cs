using WpfMessengerApp.Services;

namespace WpfMessengerApp.ViewModel
{
    public class MainWindowViewModel
    {
        public MainWindowViewModel()
        {
            LocalizationService = new MainLocalizationService();
        }

        public IMainLocalizationService LocalizationService { get; set; }
    }
}
