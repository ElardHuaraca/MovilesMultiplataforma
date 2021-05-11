using System;
using System.Collections.Generic;
using System.Text;

namespace DependecyService
{
    public interface ITextToSpeech
    {
        void Speak(string text);
    }
}
