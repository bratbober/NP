using System.Net;
using System.Net.Sockets;

namespace _006_MulticastClient
{
    public partial class Form1 : Form
    {

        Bitmap pict;
        string ip = "224.5.6.11";
        UdpClient client;
        IPAddress groupAddress;
        int localPort;
        int remotePort;
        int ttl;

        IPEndPoint remoteEndPoint;


        public Form1()
        {
            InitializeComponent();

            try {
                groupAddress = IPAddress.Parse(ip);
                localPort = 7778;
                remotePort = 7777;
                ttl = 32;
                client = new UdpClient(localPort);
                client.JoinMulticastGroup(groupAddress);
                remoteEndPoint = new IPEndPoint(groupAddress, remotePort);

                Task.Run(() => Listener());
            }
            catch { }
            

        }

        private void Listener()
        {
            try
            {
                while (true) {
                    IPEndPoint ep = null;
                    byte[] data = client.Receive(ref ep);

                    using MemoryStream ms = new MemoryStream(data);

                    pict = new Bitmap(ms);

                    pictureBox1.Invoke(() =>
                    {
                        pictureBox1.Image = pict;
                    });
                }
            }
            catch { }
        }
    }
}
