using System;
using System.Collections.Generic;
using System.Text;

namespace GuessEXE.Core
{
    public interface IGuesserListener
    {
        void guessInfo(int priority, string info);
        void guessAttribute(string attribute, string value);
    }
}
