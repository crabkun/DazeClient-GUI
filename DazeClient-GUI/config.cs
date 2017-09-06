using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DazeClient_GUI
{
    public class Server
    {
        public string Name;
        public string Address;
        public string Port;
        public string Username;
        public string Password;
        public string Encryption;
        public string EncryptionParam;
        public string Obscure;
        public string ObscureParam;
    }
    public  class Config
    {
        public Server[] Servers;
        public string LocalPort;
        public int LastServer;
    }
}
