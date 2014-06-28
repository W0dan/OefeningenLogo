using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using OefeningenLogo.Backend;
using OefeningenLogo.UI;
using OefeningenLogo.UI.CreateExercise.AddNumber;

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
                    .BasedOn<IRepository>()
                    .WithServiceAllInterfaces()
                    .LifestyleSingleton())
                .Register(Classes.FromThisAssembly()
                    .BasedOn<IWindow>()
                    .WithServiceAllInterfaces()
                    .LifestyleTransient())
                ;
        }
    }
}