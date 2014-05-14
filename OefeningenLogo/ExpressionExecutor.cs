using System;

namespace OefeningenLogo
{
    public class ExpressionExecutor
    {
        public static Exception _lastException;

        public static decimal? Execute(string code)
        {
            try
            {
                using (var codeProvider = new Microsoft.CSharp.CSharpCodeProvider())
                {
                    var csharpCode = string.Format("public class ExecutorClass {{ public decimal Execute() {{ return {0};}} }}", code);
                    var res = codeProvider.CompileAssemblyFromSource(
                        new System.CodeDom.Compiler.CompilerParameters
                            {
                                GenerateInMemory = true
                            },
                        csharpCode
                        );

                    var type = res.CompiledAssembly.GetType("ExecutorClass");

                    var obj = Activator.CreateInstance(type);

                    return (decimal)type.GetMethod("Execute").Invoke(obj, new object[] { });
                }
            }
            catch (Exception ex)
            {
                _lastException = ex;
                return null;
            }
        }

        public static Exception LastException
        {
            get { return _lastException; }
        }
    }
}
