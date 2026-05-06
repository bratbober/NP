using System.Net;
using System.Net.Sockets;
using System.Text;

namespace _003_ChatClient
{
    public partial class Form1 : Form
    {
        Socket sendSocket = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            // 3. Send data to the server

            string message = textBox2.Text;
            byte[] data = Encoding.ASCII.GetBytes(message);

            sendSocket.Send(data);

            
        }

        private void RecieveData(Socket receiveSocket)
        {
            while (true)
            {
                byte[] data = new byte[1024];
                int bytes = receiveSocket.Receive(data);
                string message = Encoding.ASCII.GetString(data, 0, bytes);
                Invoke(() =>
                {
                    textBox3.Text += message;
                });
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // 1. Create a socket
            sendSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            string ipStr = textBox1.Text;
            IPAddress ip = IPAddress.Parse(ipStr);
            int port = 22000;

            IPEndPoint iPEndPoint = new IPEndPoint(ip, port);

            // 2. Connect to the server

            sendSocket.Connect(iPEndPoint);

            // 4. Receive message
            Task.Run(() => RecieveData(sendSocket));

            button2.Enabled = false;     
        }
    }
}
