using System.Data;

namespace _010_WeatherTask
{
    public partial class Form1 : Form
    {
        HttpClient httpClient = new HttpClient();
        
        public Form1()
        {
            InitializeComponent();

            label4.Text = DateTime.Now.ToShortDateString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string city = textBox1.Text;
            string uri = "https://api.openweathermap.org/data/2.5/weather?mode=xml&units=metric&q=city&appid=595b83742bd73770b24aaca75c5444a3";

            
        }
    }
}
