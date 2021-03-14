using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jubilant_Server
{
    public static class Debug
    {

        public static void LogWarning(string msg)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            string prefix = $"[{DateTime.Now:HH:mm:ss} : Warning]";
            Console.WriteLine(FormatLines(msg, prefix));
            Console.ResetColor();
        }

        public static void LogInfo(string msg)
        {
            string prefix = $"[{DateTime.Now.ToString("HH:mm:ss")} : Info]";
            Console.WriteLine(FormatLines(msg, prefix));
        }

        public static void LogError(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            string prefix = $"[{DateTime.Now.ToString("HH:mm:ss")} : Error]";
            Console.WriteLine(FormatLines(msg, prefix));
            Console.ResetColor();
        }

        private static string FormatLines(string msg, string prefix)
        {
            string[] lines = msg.Split("\n");
            StringBuilder result = new();
            result.Append(prefix + " ");
            result.Append(lines[0]);

            StringBuilder whitespaces = new();
            for (int i = 0; i <= prefix.Length; i++)
            {
                whitespaces.Append(' ');
            }

            for (int i = 1; i < lines.Length; i++)
            {
                result.Append('\n');
                result.Append(whitespaces);
                result.Append(lines[i]);
            }

            return result.ToString();
        }
    }
}
