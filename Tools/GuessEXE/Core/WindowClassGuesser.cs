using System;
using System.Collections.Generic;
using System.Text;
using ManagedWinapi.Windows;
using System.IO;

namespace GuessEXE.Core
{
    class WindowClassGuesser : IWindowGuesser
    {

        SubsetParser sp;

        public WindowClassGuesser(TextReader config)
        {
            sp = new SubsetParser("WNDCLASS,", config);
        }

        #region IWindowGuesser Members

        public void guess(IGuesserListener listener, SystemWindow window)
        {
            string mainclass = window.ClassName;
            List<string> childClasses = new List<string>();
            childClasses.Add(mainclass);
            parseChildren(childClasses, window);
            childClasses.Sort();
            listener.guessInfo(1, "** Main class: " + mainclass);
            foreach (string c in childClasses)
            {
                listener.guessInfo(2, "*** Child class:" + c);
            }
            IList<string> results = sp.parse(mainclass, childClasses.ToArray());
            foreach (string r in results)
            {
                listener.guessInfo(0, "Wndclass suggests: " + r);
                listener.guessAttribute("WNDCLASS", r);
            }
        }

        private void parseChildren(List<string> toFill, SystemWindow window)
        {
            foreach (SystemWindow child in window.AllChildWindows)
            {
                string clazz = child.ClassName;
                if (!toFill.Contains(clazz)) toFill.Add(clazz);
                parseChildren(toFill, child);
            }
        }

        #endregion
    }
}
