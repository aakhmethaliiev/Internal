using System.Collections.ObjectModel;
using Caliburn.Micro;
using Contracts;

namespace MessengerApp.ViewModel
{
    public class MainWindowViewModel: PropertyChangedBase
    {
        public MainWindowViewModel()
        {
            MenuItems = new ObservableCollection<ShellMenuItem>();
        }

        public ObservableCollection<ShellMenuItem> MenuItems { get; private set; }

        private ShellMenuItem _selectedMenuItem;
        public ShellMenuItem SelectedMenuItem
        {
            get => _selectedMenuItem;
            set
            {
                if (_selectedMenuItem == value)
                    return;
                _selectedMenuItem = value;
                NotifyOfPropertyChange(() => SelectedMenuItem);
                NotifyOfPropertyChange(() => CurrentView);
            }
        }

        public object CurrentView => _selectedMenuItem?.ScreenViewModel;
    }
}
