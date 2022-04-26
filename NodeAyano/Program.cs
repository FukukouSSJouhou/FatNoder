using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Loader;
using System.Text;
using System.Threading.Tasks;

namespace NodeAyano
{
    public class Program
    {
        private static readonly string samplestrclass = @"
            using System;
            namespace ExampleNo1{
                public class MainObj{
                    public string Retkun(string a){
                        return a;
                    }
                    static int Main(string[] args){
                        Console.WriteLine(810);
                        return 0;
                    }
                }
            }
        ";
        static int Main(string[] args)
        {
            Console.WriteLine("Start");
            /*
            var options = CSharpParseOptions.Default
                .WithLanguageVersion(LanguageVersion.CSharp10); 
            var syntaxTrees = new List<SyntaxTree>();
            var assemblyDirectoryPath = Path.GetDirectoryName(typeof(object).Assembly.Location);
            var references = new MetadataReference[]
            {
                MetadataReference.CreateFromFile(
                    $"{assemblyDirectoryPath}/mscorlib.dll"),
                MetadataReference.CreateFromFile(
                    $"{assemblyDirectoryPath}/System.Runtime.dll"),
                MetadataReference.CreateFromFile(
                    typeof(object).Assembly.Location),
                MetadataReference.CreateFromFile(
                    typeof(System.Console).Assembly.Location),
            };
            var syntaxTree = CSharpSyntaxTree.ParseText(
                samplestrclass,
                options,
                "MainObj.cs"
            );
            syntaxTrees.Add(syntaxTree);
            var compilation = CSharpCompilation.Create("MainObj", syntaxTrees, references);
            Console.WriteLine("a");
            */
            
            return 0;
        }
    }
}
