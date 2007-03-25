using System;
using System.Collections.Generic;
using System.Text;
using ManagedWinapi.Windows;
using System.ComponentModel;

namespace GuessEXE.Core
{
    class WindowExecutableGuesser : IWindowGuesser
    {

        Controller ctrl;

        public WindowExecutableGuesser(Controller ctrl)
        {
            this.ctrl = ctrl;
        }

        #region IWindowGuesser Members

        public void guess(IGuesserListener listener, SystemWindow window)
        {
            string file;
            try
            {
                file = window.Process.MainModule.FileName;
            }
            catch (Win32Exception)
            {
                listener.guessInfo(2, "*** File access denied");
                return;
            }
            listener.guessInfo(2, "*** Detected File: " + file);
            ctrl.guessFile(listener, file);
        }

        #endregion
    }
}
