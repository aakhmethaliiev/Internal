using System.Reflection;
using Contracts;
using Microsoft.Win32;

namespace Module.ViewModels
{
    public class SecondViewModel
    {
        private readonly IShell _shell;

        public SecondViewModel(IShell shell)
        {
            _shell = shell;
        }

        public void Load()
        {
            var dlg = new OpenFileDialog();

            if (dlg.ShowDialog().GetValueOrDefault())
            {
                var asm = Assembly.LoadFrom(dlg.FileName);
                var module = _shell.LoadModule(asm);
                module?.Init();
            }
        }
    }
}
