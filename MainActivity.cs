using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System.Net.Http;
using System;

namespace WeatherApp
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {

        Button getWeatherButton;
        TextView placeTextView;
        TextView temperatureTextView;
        TextView weatherDescriptionTextView;
        EditText cityNameEditText;
        ImageView weatherImageView;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_main);

            cityNameEditText = (EditText)FindViewById(Resource.Id.cityNameText);
            placeTextView = (TextView)FindViewById(Resource.Id.placeText);
            temperatureTextView = (TextView)FindViewById(Resource.Id.temperatureTextView);
            weatherDescriptionTextView = (TextView)FindViewById(Resource.Id.weatherDescriptionText);
            getWeatherButton = (Button)FindViewById(Resource.Id.getWeatherButton);
            weatherImageView = (ImageView)FindViewById(Resource.Id.weatherImage);


            getWeatherButton.Click += GetWeatherButton_Click;

        }

        private void GetWeatherButton_Click(object sender, System.EventArgs e)
        {
            string place = cityNameEditText.Text;
            GetWeather(place);

        }

        async void GetWeather(string place)
        {
            string apiKey = "0aff97794c581a0187aef2b78776d203";
            string apiBase = "https://api.openweathermap.org/data/2.5/weather?q=";
            string unit = "metric";

            if (string.IsNullOrEmpty(place))
            {
                Toast.MakeText(this, "please enter a valid city name", ToastLength.Short).Show();
                return;
            }

            string url = apiBase + place + "&appid=" + apiKey + "&units=" + unit;

            var handler = new HttpClientHandler();

            HttpClient client = new HttpClient(handler);

            string result = await client.GetStringAsync(url);

            Console.WriteLine(result);
        }
    }
}