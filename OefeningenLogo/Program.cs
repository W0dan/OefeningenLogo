using System;
using System.Windows.Forms;
using Castle.Windsor;
using Castle.Windsor.Installer;
using OefeningenLogo.UI;

namespace OefeningenLogo
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var container = new WindsorContainer();

            container.Install(FromAssembly.This());

            var rootController = container.Resolve<IRootController>();
            Application.Run(rootController.Window);

            container.Dispose();

            //Application.Run(new MaakOefeningen());
        }
    }
}
