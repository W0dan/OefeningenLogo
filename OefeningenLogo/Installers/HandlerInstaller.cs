﻿using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using OefeningenLogo.Service;

namespace OefeningenLogo.Installers
{
    public class HandlerInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container
                .Register(Classes.FromThisAssembly()
                    .BasedOn<IHandler>()
                    .WithServiceAllInterfaces()
                    .LifestyleTransient())
                ;
        }
    }
}