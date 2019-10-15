using MessengerModel.Model;

namespace MessengerApp.ViewModel
{
    internal class MainWindowViewModel : ViewModelBase
    {
        private Model _model;

        public MainWindowViewModel()
        {
        }

        public MainWindowViewModel(Model model)
        {
            _model = model;
        }
    }
}
