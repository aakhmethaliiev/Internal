using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Contracts;
using MessengerApp.ViewModel;

namespace MessengerApp
{
    class ShellInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container
                .Register(Component.For<IWindsorContainer>().Instance(container))
                .Register(Component.For<ModuleLoader>())
                .Register(Component.For<IShell>().ImplementedBy<ShellImpl>())
                .Register(Component.For<ShellViewModel>() /*.LifeStyle.Singleton*/);
        }
    }
}
