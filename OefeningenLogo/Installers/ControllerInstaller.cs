using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using OefeningenLogo.UI;

namespace OefeningenLogo.Installers
{
    public class ControllerInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container
                .Register(Classes.FromThisAssembly()
                    .BasedOn<IController>()
                    .WithServiceAllInterfaces()
                    .LifestyleTransient())
                .Register(Classes.FromThisAssembly()
                    .BasedOn<IWindow>()
                    .WithServiceAllInterfaces()
                    .LifestyleTransient())
                ;
        }
    }
}