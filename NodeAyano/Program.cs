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
            var options = CSharpParseOptions.Default
                .WithLanguageVersion(LanguageVersion.CSharp10);
            var syntaxTree = CSharpSyntaxTree.ParseText(
                samplestrclass,
                options,
                "MainObj.cs"
            );
            Console.WriteLine("tdn");

            return 0;
        }
    }
}
