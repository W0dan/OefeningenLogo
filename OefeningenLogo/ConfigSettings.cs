using System.Configuration;

namespace OefeningenLogo
{
    public static class ConfigSettings
    {
        public static string RootPath { get { return ConfigurationManager.AppSettings["RootPath"]; } }

        public static string ExerciseFile { get { return System.IO.Path.Combine(RootPath, "exercises.xml"); } }
    }
}