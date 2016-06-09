namespace GISendLib
{


    public class Class1
    {
        MainSend asr;
        public Class1()
        {
            asr = new MainSend();
        }

        public Declarations.Media.IMemoryInputMedia GetMedia()
        {
            return asr.InputMedia;
        }

        public Declarations.Players.IVideoPlayer GetPlayer()
        {
            return asr.Player;
        }

    }
}
