using Declarations.Events;
using Declarations.Media;
using Declarations.Players;
using System;

namespace GISendLib
{


    public class Class1
    {
        MainSend asr;
        public Class1()
        {
            asr = new MainSend();
        }

        public MainSend GetBase()
        {
            return asr;
        }

    }
}
