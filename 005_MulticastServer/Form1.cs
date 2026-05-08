using System.Drawing.Imaging;
using System.Net;
using System.Net.Sockets;

namespace _005_MulticastServer
{
    public partial class Form1 : Form
    {
        string pictureDirectory = "Pictures";
        FileInfo[] fi;

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

            // multicast setting

            groupAddress = IPAddress.Parse(ip);
            localPort = 7777;
            remotePort = 7778;
            ttl = 32;
            client = new UdpClient(localPort);
            client.JoinMulticastGroup(groupAddress, ttl);
            remoteEndPoint = new IPEndPoint(groupAddress, remotePort);


            // select image
            DirectoryInfo di = new DirectoryInfo(pictureDirectory);

            fi = di.GetFiles();

            foreach (FileInfo item in fi)
            {
                comboBox1.Items.Add(item.Name);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            pict = new Bitmap($"{pictureDirectory}/{comboBox1.SelectedItem}");
            pictureBox1.Image = pict;


            Task.Run(() => SenderImage((Bitmap)pict.Clone()));
        }

        private void SenderImage(Bitmap bitmap)
        {
            using MemoryStream ms = new MemoryStream();

            bitmap.Save(ms, ImageFormat.Jpeg);
            byte[] data = ms.ToArray();
            client.Send(data, data.Length, remoteEndPoint);
        }
    }
}
