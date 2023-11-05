using System;
using System.Collections;
using _Project.Scripts.Runner.Utilities;
using UnityEngine;
using UnityEngine.Networking;

namespace _Project.Scripts.Runner.Game.Network
{
    public class NetworkManager : Manager
    {
        private string city = "London"; // Replace with the desired city name
        private WeatherData _weatherData;
        public NetworkData networkData;

        private void Start()
        {
            StartCoroutine(FetchWeatherData());
        }

        private IEnumerator FetchWeatherData()
        {
            string url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={networkData.apiKey}";
            using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
            {
                yield return webRequest.SendWebRequest();

                if (webRequest.result == UnityWebRequest.Result.Success)
                {
                    string responseJson = webRequest.downloadHandler.text;
                    _weatherData = JsonUtility.FromJson<WeatherData>(responseJson);

                    if (_weatherData != null)
                    {
                        // You can access weatherData properties here
                        float kelvinTemperature = _weatherData.main.temp;
                        float celsiusTemperature = kelvinTemperature.ToCelsius();
                        float fahrenheitTemperature = kelvinTemperature.ToFahrenheit();
                        Debug.Log($"Temperature in Celsius: {celsiusTemperature}°C");
                        Debug.Log($"Temperature in Fahrenheit: {fahrenheitTemperature}°F");
                        
                        int sunriseTimestamp = _weatherData.sys.sunrise;
                        DateTime sunriseTime = sunriseTimestamp.ToDateTime();
                        int sunsetTimestamp = _weatherData.sys.sunset;
                        DateTime sunsetTime = sunsetTimestamp.ToDateTime();
                        
                        Debug.Log($"Sunrise time: {sunriseTime}");                        
                        Debug.Log($"Sunset time: {sunsetTime}");
                    }
                    else
                    {
                        Debug.LogError("Failed to parse weather data.");
                    }
                }
                else
                {
                    Debug.LogError("Failed to fetch weather data: " + webRequest.error);
                }
            }
        }
        

    }
    
}