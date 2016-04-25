
namespace GIShowCam.Info
{
    public struct Device
    {
        public string adresa;
        public string user;
        public string parola;

        public Device(string adresa, string user, string parola) : this()
        {
            this.adresa = adresa;
            this.user = user;
            this.parola = parola;
        }

        public Device(Device device) : this(device.adresa, device.user, device.parola)
        {
        }
    }
}
