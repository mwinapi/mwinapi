using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace GuessEXE.Core
{
    class StubGuesser : IFileGuesser
    {
        public void guess(IGuesserListener listener, string file)
        {
            try
            {
                String stub = new ExeParser(file).StubSignature;
                listener.guessInfo(1, "** EXE Stub signature: " + stub);
                listener.guessAttribute("STUB", stub);
            }
            catch (EXEFormatException ex)
            {
                listener.guessInfo(1, "** EXE Format: " + ex.Message);
            }
        }
    }

    class SectionGuesser : IFileGuesser
    {
        SubsetParser sp;

        public SectionGuesser(TextReader config)
        {
            sp = new SubsetParser("SECTION,", config);
        }

        public void guess(IGuesserListener listener, string file)
        {
            try
            {
                IList<ExeSection> ss = new ExeParser(file).Sections;
                string[] names = new string[ss.Count];
                int count = 0;
                foreach (ExeSection s in ss)
                {
                    listener.guessInfo(2, "** Section: " + s.Name);
                    names[count++] = s.Name;
                }
                List<string> results = sp.parse("", names);
                foreach (string result in results)
                {
                    listener.guessInfo(0, "EXE Sections suggest: " + result);
                    listener.guessAttribute("SECTIONS", result);
                }
            }
            catch (EXEFormatException) { }
        }
    }

    class ImportGuesser : IFileGuesser
    {
        SubsetParser sp;

        public ImportGuesser(TextReader config)
        {
            sp = new SubsetParser("IMPORT,", config);
        }

        public void guess(IGuesserListener listener, string file)
        {
            try
            {
                ExeParser ep = new ExeParser(file);
                IList<ImportTableEntry> imps = ep.ImportTable;
                string[] dlls = new string[imps.Count];
                int count = 0;
                foreach (ImportTableEntry imp in imps)
                {
                    dlls[count++] = imp.DLL;
                    listener.guessInfo(1, "** Uses DLL: " + imp.DLL);
                }
                IList<string> results = sp.parse("", dlls);
                foreach (string result in results)
                {
                    listener.guessInfo(0, "DLLImports suggest: " + result);
                    listener.guessAttribute("IMPORTS", result);
                }
            }
            catch (EXEFormatException ex)
            {
                listener.guessInfo(1, "** EXE Format: " + ex.Message);
            }
        }
    }
}
