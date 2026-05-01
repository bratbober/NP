using System.Net;
using System.Net.Sockets;
using System.Text;

namespace _002_ChatServer
{
    public partial class Form1 : Form
    {
        Socket listenSocket = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 1. Create a socket

            int port = 22000;

            listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            string ipStr = "192.168.43.6";
            IPAddress ip = IPAddress.Parse(ipStr);

            /*IPHostEntry entry = Dns.GetHostEntry("localhost");
            IPAddress ip = entry.AddressList[0];*/

            IPEndPoint iPEndPoint = new IPEndPoint(ip, port);

            // 2. Bind the socket to an endpoint 

            listenSocket.Bind(iPEndPoint);

            Task.Run(() => ListenThread(listenSocket));
        }

        private void ListenThread(Socket listenSocket)
        {
            // 3. Start listening for incoming connections
            listenSocket.Listen(10);

            while (true)
            {
                // Block function
                Socket clientSocket = listenSocket.Accept();

                Info info = new Info()
                {
                    ClientSocket = clientSocket,
                    RemoteEndPoint = clientSocket.RemoteEndPoint.ToString()
                };
                listBox1.Invoke(() => listBox1.Items.Add(info));

                Task.Run(() => ReceiveThread(clientSocket));
            }
        }

        private void ReceiveThread(Socket clientSocket)
        {
            int bytes = 0;
            byte[] data = new byte[1024];
            string message;

            while (true)
            {
                // 4. Receive data from the client

                bytes = clientSocket.Receive(data);
                message = Encoding.ASCII.GetString(data, 0, bytes);

                textBox1.Invoke(() => textBox1.Text += message);
            }
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

        private void button2_Click(object sender, EventArgs e)
        {
            string message = textBox2.Text;

            Info info = (Info)listBox1.SelectedItem;

            byte[] data = Encoding.ASCII.GetBytes(message);

            info.ClientSocket.Send(data);
        }
    }
}
