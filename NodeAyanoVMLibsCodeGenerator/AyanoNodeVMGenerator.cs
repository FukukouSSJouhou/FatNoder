using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;
namespace NodeAyanoVMLibsCodeGenerator
{
    [Generator]
    public class AyanoNodeVMGenerator : ISourceGenerator
    {
        private const string attributeText = @"
using System;
namespace AyanoNodeVM
{
    [AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
    [System.Diagnostics.Conditional(""AyanoNodeVMGenerator_DEBUG"")]
    sealed class ModelAyanoAttribute:Attribute
    {
        public ModelAyanoAttribute(){
            
        }
    }
}
";
        public void Execute(GeneratorExecutionContext context)
        {
            throw new NotImplementedException();
        }

        public void Initialize(GeneratorInitializationContext context)
        {
            throw new NotImplementedException();
        }
    }
}
