using System;
using System.Collections.Generic;
using System.Text;
using GuessEXE.Core;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;

namespace GuessEXE
{
    class CommandLineInterface : IGuesserListener
    {
        List<string> attrs = new List<string>();
        int verbosity;

        public void guessInfo(int priority, string info)
        {
            if (priority > verbosity) return;
            Console.WriteLine("\t\t\t".Substring(0, priority) + info);
        }

        public void guessAttribute(string attribute, string value)
        {
            attrs.Add(attribute + "=" + value);
        }

        internal void Run(string[] args)
        {
            verbosity = 0;
            for (int i = 1; i < args.Length; i++)
            {
                string cmd = args[i];
                if (new Regex("^[/-][vV]+$").IsMatch(cmd))
                {
                    verbosity += cmd.Length - 1;
                }
                else
                {

                    try
                    {
                        Controller ctrl = new Controller();
                        attrs.Clear();
                        attrs.Add("WNDCLASS=untested");
                        ctrl.guessFile(this, cmd);
                        ctrl.summarize(this, attrs.ToArray());
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                }
            }
        }
    }
}
