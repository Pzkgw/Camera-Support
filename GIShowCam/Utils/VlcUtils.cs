
using Declarations;


namespace GIShowCam.Utils
{
    internal static class VlcUtils
    {

        internal static string AspectRatioToString(AspectRatioMode aratio)
        {
            switch (aratio) // toate cele 9 vlc aspect ratio values
            {
                case AspectRatioMode.Mode1:
                    return "1:1";
                case AspectRatioMode.Mode2:
                    return "4:3";
                case AspectRatioMode.Mode3:
                    return "16:9";
                case AspectRatioMode.Mode4:
                    return "16:10";
                case AspectRatioMode.Mode5:
                    return "2.21:1";
                case AspectRatioMode.Mode6:
                    return "2.35:1";
                case AspectRatioMode.Mode7:
                    return "2.39:1";
                case AspectRatioMode.Mode8:
                    return "5:4";
                case AspectRatioMode.Default:
                    return "Default";
                default:
                    return null;
            }
        }
    }
}
