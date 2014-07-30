using System.CodeDom.Compiler;
using System.Reflection;
using Microsoft.CSharp;
using OefeningenLogo.Oefeningen;

namespace OefeningenLogo.Service
{
    public static class ConstraintBuilder
    {
        public static IConstraint BuildConstraint(string value, string name)
        {
            var definition =
                string.Format(@"public class Constraint : OefeningenLogo.Oefeningen.IConstraint
{{
    public bool IsValid(params decimal[] numbers)
    {{
        return {0};
    }}

    public override string ToString()
    {{
        return ""{1}"";
    }}
}}", value, name);

            var csCompiler = new CSharpCodeProvider();
            var compilerParameters = new CompilerParameters
            {
                GenerateInMemory = true,
                GenerateExecutable = false
            };
            var location = Assembly.GetExecutingAssembly().Location;
            compilerParameters.ReferencedAssemblies.Add(location);
            var results = csCompiler.CompileAssemblyFromSource(compilerParameters, new[] { definition });

            IConstraint constraint = null;

            if (results.Errors.Count == 0)
            {
                var assembly = results.CompiledAssembly;
                constraint = assembly.CreateInstance("Constraint") as IConstraint;
            }

            return constraint;
        }
    }
}