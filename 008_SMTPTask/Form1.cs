using System.Net;
using System.Net.Mail;

namespace _008_SMTPTask
{
    public partial class Form1 : Form
    {
        string code;
        DateTime time;
        Random random = new Random();

        public Form1()
        {
            InitializeComponent();
            button2.Enabled = false;
        }


        private async void button1_Click(object sender, EventArgs e)
        {
            await SendingProcess();
        }
        private async void button2_Click(object sender, EventArgs e)
        {
            await SendingProcess();
        }
        private async Task SendingProcess()
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Введіть email!");
                return;
            }

            code = random.Next(100000, 999999).ToString();
            time = DateTime.Now.AddMinutes(1);

            try
            {

                button1.Enabled = false;
                button2.Enabled = false;

                await SendEmailAsync(textBox1.Text, code);

                timer1.Start();
                MessageBox.Show("Код надіслано");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка відправки: {ex.Message}");
                button1.Enabled = true;
            }
        }
        public async Task SendEmailAsync(string targetEmail, string code)
        {
            string smtpAddress = "smtp.gmail.com";
            int port = 587;
            string userName = "maks.fedak334@gmail.com";
            string appPassword = "rtsh kxyc jsdy ncio";

            MailMessage message = new MailMessage(userName, targetEmail);
            SmtpClient smtpClient = new SmtpClient(smtpAddress, port);

            try
            {
                message.Subject = "Код відновлення пароля";
                message.IsBodyHtml = true;
                message.Body = $"<h1 style='color:blue;'>Ваш код: {code}</h1><p>Дійсний 1 хвилину.</p>";

                smtpClient.Credentials = new NetworkCredential(userName, appPassword);
                smtpClient.EnableSsl = true;

                await smtpClient.SendMailAsync(message);
            }
            finally
            {
                message.Dispose();
                smtpClient.Dispose();
            }
        }     
        private void button3_Click(object sender, EventArgs e)
        {
            if (code != null && textBox2.Text == code)
            {
                timer1.Stop();
                MessageBox.Show("Доступ дозволено!", "Success");
            }
            else
            {
                string errorMsg = (code == null) ? "Час дії коду вичерпано!" : "Невірний код!";
                MessageBox.Show(errorMsg, "Error");
            }
        }
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            TimeSpan diff = time - DateTime.Now;

            if (diff.TotalSeconds > 0)
            {
                label3.Text = $"Залишилось: {diff.Seconds} сек.";
            }
            else
            {
                timer1.Stop();
                code = null;
                label1.Text = "Час вийшов!";


                button2.Enabled = true;
                button1.Enabled = true;
            }
        }
    }
}