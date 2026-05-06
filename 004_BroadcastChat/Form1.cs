using System.Net;
using System.Net.Sockets;

namespace _004_BroadcastChat
{
    public partial class Form1 : Form
    {
        UdpClient clientSend = null;
        UdpClient clientReceive = null;
        UdpClient messageSend = null;
        UdpClient messageReceive = null;

        int portSend = 47023;
        int portReceive = 47025;
        int portMessageSend = 47020;
        int portMessageReceive = 47021;

        string ip = "192.168.43.6";


        public Form1()
        {
            InitializeComponent();

            IPAddress ipAddress = IPAddress.Parse(ip);

            clientSend = new UdpClient(new IPEndPoint(ipAddress, portSend));
            clientReceive = new UdpClient(new IPEndPoint(ipAddress, portReceive));
            messageSend = new UdpClient(new IPEndPoint(ipAddress, portMessageSend));
            messageReceive = new UdpClient(new IPEndPoint(ipAddress, portMessageReceive));

            // Get message from connection
            Task.Run(() =>
            {
                while (true)
                {
                    IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Any, portReceive);

                    byte[] data = clientReceive.Receive(ref iPEndPoint);

                    MyMessage message = Serializer.ByteArrayToObject<MyMessage>(data);

                    // string message = Encoding.ASCII.GetString(data, 0, data.Length);

                    listBox1.Invoke(() =>
                    {
                        if (!listBox1.Items.Contains(message.ComputerName))
                            listBox1.Items.Add(message.ComputerName);
                        if (!message.IsOnline)
                        {
                            listBox1.Items.Remove(message.ComputerName);
                        }
                    });
                }
            });

            // Get message from user
            Task.Run(() =>
            {
                while (true)
                {
                    IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Any, portMessageReceive);

                    byte[] data = messageReceive.Receive(ref iPEndPoint);

                    MyMessage message = Serializer.ByteArrayToObject<MyMessage>(data);


                    textBox1.Invoke(() =>
                    {
                        textBox1.Text += $"{message.ComputerName}:{message.Message}{Environment.NewLine}";
                    });
                }
            });
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            MyMessage myMessage = new MyMessage()
            {
                ComputerName = SystemInformation.ComputerName,
                IsOnline = true,
            };

            byte[] data = Serializer.ObjectToByteArray(myMessage);

            /* string computerName = SystemInformation.ComputerName;
             byte[] data = Encoding.ASCII.GetBytes(computerName);*/
            try
            {
                clientSend.Connect(IPAddress.Broadcast, portReceive);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            clientSend.Send(data, data.Length);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            MyMessage myMessage = new MyMessage()
            {
                ComputerName = SystemInformation.ComputerName,
                IsOnline = false,
            };

            byte[] data = Serializer.ObjectToByteArray(myMessage);

            try
            {
                clientSend.Connect(IPAddress.Broadcast, portReceive);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            clientSend.Send(data, data.Length);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "") { MessageBox.Show("Enter message"); return; }

            MyMessage myMessage = new MyMessage()
            {
                ComputerName = SystemInformation.ComputerName,
                Message = textBox2.Text,
            };

            byte[] data = Serializer.ObjectToByteArray(myMessage);

            try
            {
                messageSend.Connect(IPAddress.Broadcast, portMessageReceive);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            messageSend.Send(data, data.Length);
        }
    }
}
