using AyanoBuilder.CUItools;
using Microsoft.Extensions.CommandLineUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AyanoBuilder.compilers
{
    /// <summary>
    /// Compiler CUI
    /// </summary>
    public class CUIProgram
    {
        /// <summary>
        /// Main CUI EntryPoint
        /// </summary>
        /// <param name="args">Arguments</param>
        /// <returns>Exit Code</returns>
        public static int MainCUI(string[] args)
        {
            var app = new CommandLineApplication(throwOnUnexpectedArg: false);
            app.Name = "AyanoBuilder for FatNoder";
            app.Description = "Transcompiler for FatNoder";
            app.HelpOption("-h|--help");
            app.OnExecute(() =>
            {

                ConsoleWrapper.BluePrint("[AyanoBuilder]");
                return 0;
            });
            return app.Execute(args);
        }
    }
}
