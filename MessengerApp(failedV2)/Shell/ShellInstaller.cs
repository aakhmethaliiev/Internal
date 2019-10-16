using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Contracts;
using Shell.ViewModels;

namespace Shell
{
    public class ShellInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container
                .Register(Component.For<IWindsorContainer>().Instance(container))
                .Register(Component.For<ShellViewModel>() /*.LifeStyle.Singleton*/)
                .Register(Component.For<ModuleLoader>())
                .Register(Component.For<IShell>().ImplementedBy<ShellImpl>());
        }
    }
}
