using System;
using System.Collections.Generic;
using System.Text;
using ManagedWinapi.Windows;

namespace GuessEXE.Core
{
    interface IWindowGuesser
    {
        void guess(IGuesserListener listener, SystemWindow window);
    }
}
