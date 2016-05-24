
using System;

namespace GIShowCam.Info
{
    public struct Device : IDisposable
    {
        public string Adresa;
        public string User;
        public string Parola;

        internal DeviceInfo Data;

        public Device(string adresa, string user, string parola) : this()
        {
            Adresa = adresa;
            User = user;
            Parola = parola;

            Data = new DeviceInfo();
        }
        
        public Device(string adresa) : this(adresa, null, null)
        {
        }

        public Device(Device device) : this(device.Adresa, device.User, device.Parola)
        {
        }

        void IDisposable.Dispose()
        {
            Data = null;
        }
    }
}
