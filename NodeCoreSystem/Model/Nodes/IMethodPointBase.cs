using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NodeCoreSystem.Model.Nodes
{
    /// <summary>
    /// Method Generate Interface
    /// </summary>
    public interface IMethodPointBase
    {
        /// <summary>
        /// Compile method?
        /// </summary>
        /// <returns>MethodDeclarationSyntax</returns>
        MethodDeclarationSyntax CompileMethodSyntax();
    }
}
