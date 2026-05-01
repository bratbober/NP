using System.Net;
using System.Net.Sockets;

namespace _001_PortScanner
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Task.Run(() => 
            {
                string ipStr = "192.168.43.6";

                /*string ipStr = GetLocalIPAddress();
                MessageBox.Show(ipStr);*/

                IPAddress ip = IPAddress.Parse(ipStr);

                Socket socket = null;

                int start = 130, end = 140;

                for (int i = start; i < end; i++)
                {
                    try
                    {
                        IPEndPoint iPEndPoint = new IPEndPoint(ip, i);

                        socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                        socket.Connect(iPEndPoint);
                        listBox1.Invoke(() =>
                        {
                            listBox1.Items.Add($"Port {i} is busy!");
                        });

                    }
                    catch
                    {
                        listBox1.Invoke(() =>
                        {
                            listBox1.Items.Add($"Port {i} is free!");
                        });
                    }
                    finally
                    {
                        socket?.Close();
                    }
                }
            });

            
        }

        public string GetLocalIPAddress()
        {
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }
    }
}
