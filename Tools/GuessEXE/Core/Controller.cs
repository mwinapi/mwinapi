using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.IO;

namespace GuessEXE.Core
{
    public class Controller
    {

        List<IFileGuesser> fileGuessers = new List<IFileGuesser>();
        List<IWindowGuesser> windowGuessers = new List<IWindowGuesser>();

        SubsetParser summary;
        public Controller()
        {
            Stream s = Assembly.GetExecutingAssembly().GetManifestResourceStream("GuessEXE.magic.txt");
            fileGuessers.Add(new StubGuesser());
            fileGuessers.Add(new SectionGuesser(new StreamReader(s)));
            s = Assembly.GetExecutingAssembly().GetManifestResourceStream("GuessEXE.magic.txt");
            fileGuessers.Add(new ImportGuesser(new StreamReader(s)));
            s = Assembly.GetExecutingAssembly().GetManifestResourceStream("GuessEXE.magic.txt");
            summary = new SubsetParser("SUMMARY,", new StreamReader(s));
            s = Assembly.GetExecutingAssembly().GetManifestResourceStream("GuessEXE.magic.txt");
            windowGuessers.Add(new WindowClassGuesser(new StreamReader(s)));
            windowGuessers.Add(new WindowExecutableGuesser(this));
        }

        public void guessFile(IGuesserListener listener, string file)
        {
            foreach (IFileGuesser g in fileGuessers)
            {
                g.guess(listener, file);
            }
        }


        internal void guessWindow(IGuesserListener listener, ManagedWinapi.Windows.SystemWindow window)
        {
            foreach (IWindowGuesser g in windowGuessers)
            {
                g.guess(listener, window);
            }
        }

        internal string summarize(IGuesserListener listener, string[] attributes)
        {
            foreach (string att in attributes)
            {
                listener.guessInfo(2, "** Summary attribute: " + att);
            }
            List<string> r = summary.parse("", attributes);
            string ss;
            if (r.Count > 0)
                ss = r[0];
            else
                ss = "UNKNOWN";
            listener.guessInfo(0, "Summary: " + ss);
            return ss;
        }
    }
}

