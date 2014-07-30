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

            //bootstrapping windsor
            var container = new WindsorContainer();
            container.Install(FromAssembly.This());
            var navController = container.Resolve<INavigationController>();

            Application.Run(navController.GetStartupWindow());

            container.Dispose();

        }
    }
}
