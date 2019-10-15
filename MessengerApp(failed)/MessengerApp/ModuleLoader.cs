using System;
using System.Reflection;
using Caliburn.Micro;
using Castle.Windsor;
using Castle.Windsor.Installer;
using Contracts;

namespace MessengerApp
{
    internal class ModuleLoader
    {
        private readonly IWindsorContainer _mainContainer;

        public ModuleLoader(IWindsorContainer mainContainer)
        {
            _mainContainer = mainContainer;
        }

        public IModule LoadModule(Assembly assembly)
        {
            try
            {
                var moduleInstaller = FromAssembly.Instance(assembly);

                var windsorContainer = new WindsorContainer();

                _mainContainer.AddChildContainer(windsorContainer);

                windsorContainer.Install(moduleInstaller);

                var module = windsorContainer.Resolve<IModule>();

                if (!AssemblySource.Instance.Contains(assembly))
                    AssemblySource.Instance.Add(assembly);

                return module;
            }
            catch (Exception ex)
            {
                //TODO: good exception handling 
                return null;
            }
        }
    }
}
