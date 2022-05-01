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
            app.Command("compile", command =>
            {
                command.Description = "compile code";
                command.HelpOption("-h|--help");

                var xmlArgument = command.Argument("xml", "XML Path");
                var OutArgument = command.Argument("out", "output exe path");
                command.OnExecute(() =>
                {
                    if (xmlArgument.Value == null)
                    {
                        command.ShowHelp();
                        return 1;
                    }
                    if (OutArgument.Value == null)
                    {
                        command.ShowHelp();
                        return 1;
                    }
                    ConsoleWrapper.GreenPrint($"xml : {xmlArgument.Value} outexe:{OutArgument.Value}");
                    return 0;
                });
            });
            return app.Execute(args);
        }
    }
}
