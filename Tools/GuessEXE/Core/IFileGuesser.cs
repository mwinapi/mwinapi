using System;
using System.Collections.Generic;
using System.Text;

namespace GuessEXE.Core
{
    interface IFileGuesser
    {
        void guess(IGuesserListener listener, string file);
    }
}
