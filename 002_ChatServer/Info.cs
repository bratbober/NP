using System.Net.Sockets;

namespace _002_ChatServer
{
    public class Info
    {
        public Socket ClientSocket { get; set; }
        public string RemoteEndPoint { get; set; }

        public override string ToString()
        {
            return RemoteEndPoint;
        }
    }
}
