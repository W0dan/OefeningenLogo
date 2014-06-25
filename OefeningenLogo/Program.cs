using System;
using System.Windows.Forms;
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

            var window = new ExerciseBuilderWindow();
            new ExerciseBuilderController(window);
            Application.Run(window);

            //Application.Run(new MaakOefeningen());
        }
    }
}
