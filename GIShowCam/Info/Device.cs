
using System;

namespace GIShowCam.Info
{
    public struct Device : IDisposable
    {
        public string adresa;
        public string user;
        public string parola;

        internal DeviceInfo data;

        public Device(string adresa, string user, string parola) : this()
        {
            this.adresa = adresa;
            this.user = user;
            this.parola = parola;

            data = new DeviceInfo();
        }
        
        public Device(string adresa) : this(adresa, null, null)
        {
        }

        public Device(Device device) : this(device.adresa, device.user, device.parola)
        {
        }

        void IDisposable.Dispose()
        {
            data = null;
        }
    }
}
