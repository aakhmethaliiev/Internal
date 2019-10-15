using System.Collections.Generic;
using System.Reflection;
using Contracts;
using MessengerApp.ViewModel;

namespace MessengerApp
{
    internal class ShellImpl : IShell
    {
        private readonly ModuleLoader _loader;
        private readonly ShellViewModel _shellViewModel;

        public ShellImpl(ModuleLoader loader, ShellViewModel shellViewModel)
        {
            _loader = loader;
            _shellViewModel = shellViewModel;
        }

        public IList<ShellMenuItem> MenuItems { get { return _shellViewModel.MenuItems; } }

        public IModule LoadModule(Assembly assembly)
        {
            return _loader.LoadModule(assembly);
        }
    }
}
