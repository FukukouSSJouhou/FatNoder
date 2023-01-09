using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatBuilder.CUItools
{
    /// <summary>
    /// ANSI Console API
    /// </summary>
    public class ConsoleWrapper
    {
        /// <summary>
        /// Color Print
        /// </summary>
        /// <param name="text">Text</param>
        /// <param name="r">R</param>
        /// <param name="g">G</param>
        /// <param name="b">B</param>
        public static void PrintColor(string text, int r, int g, int b)
        {
            Console.WriteLine($"\u001b[38;2;{r};{g};{b}m{text}\u001b[0m");
        }
        /// <summary>
        /// Green print
        /// </summary>
        /// <param name="text">Text</param>
        public static void GreenPrint(string text)
        {
            PrintColor(text, 0, 255, 0);
        }
        /// <summary>
        /// Red Print
        /// </summary>
        /// <param name="text">Text</param>
        public static void RedPrint(string text)
        {
            PrintColor(text, 255,0, 0);
        }
        /// <summary>
        /// Blue Print
        /// </summary>
        /// <param name="text">Text</param>
        public static void BluePrint(string text)
        {
            PrintColor(text, 0, 0,255);
        }
    }
}
