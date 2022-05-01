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
            PrintColor("Hello", 0, 255, 0);
            return 0;
        }
        private static void PrintColor(string text,int r,int g,int b)
        {
            Console.WriteLine($"\u001b[38;2;{r};{g};{b}m{text}\u001b[0m");
        }
    }
}
