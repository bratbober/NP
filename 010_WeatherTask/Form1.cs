using _010_WeatherTask.Xml2CSharp;
using System.Xml.Serialization;

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

        private async void button1_Click(object sender, EventArgs e)
        {
            string city = textBox1.Text;
            string uri = "https://api.openweathermap.org/data/2.5/weather?mode=xml&units=metric&q=city&appid=595b83742bd73770b24aaca75c5444a3";

            try
            {
                string xmlResponse = await httpClient.GetStringAsync(uri);

            
                XmlSerializer serializer = new XmlSerializer(typeof(Current));
                Current weatherData;

                using (StringReader reader = new StringReader(xmlResponse))
                {
                    weatherData = (Current)serializer.Deserialize(reader);
                }

                Update(weatherData);
            }
            catch { }
            
        }
        private void Update(Current data)
        {
            double tempVal = double.Parse(data.Temperature.Value, System.Globalization.CultureInfo.InvariantCulture);
            TempLabel.Text = $"{Math.Round(tempVal)}°C";

            string details = $"Real Feel: {data.Feels_like.Value}°\n" +
                             $"Weather: {data.Weather.Value}\n" +
                             $"Sunrise: {data.City.Sun.Rise}\n" +
                             $"Sunset: {data.City.Sun.Set}";

            label5.Text = details;

            if (data.Weather != null && !string.IsNullOrEmpty(data.Weather.Icon))
            {
                string iconCode = data.Weather.Icon;
             
                string  iconUrl = $"https://openweathermap.org/img/wn/{iconCode}@2x.png";

                pictureBox1.ImageLocation = iconUrl;
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom; 
            }
           
        }

    }
}
