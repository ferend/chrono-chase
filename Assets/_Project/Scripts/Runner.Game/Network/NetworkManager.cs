using System;
using System.Collections;
using _Project.Scripts.Runner.Utilities;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Serialization;

namespace _Project.Scripts.Runner.Game.Network
{
    public class NetworkManager : Manager
    {
        private string city = ""; 
        [FormerlySerializedAs("networkData")] public NetworkDataSO networkDataSo;
        [FormerlySerializedAs("weatherData")] public WeatherSO weatherSoData;

        public void FetchRoutine()
        {
            city = weatherSoData.cityName;
            StartCoroutine(FetchWeatherData());
        }
        
        private IEnumerator FetchWeatherData()
        {
            yield return new WaitForSeconds(1f);
            
            string url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={networkDataSo.apiKey}";
            using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
            {
                yield return webRequest.SendWebRequest();

                if (webRequest.result == UnityWebRequest.Result.Success)
                {
                    string responseJson = webRequest.downloadHandler.text;
                    WeatherData _weatherData = JsonUtility.FromJson<WeatherData>(responseJson);

                    if (_weatherData != null)
                    {
                        // Set the CityWeatherData ScriptableObject fields
                        weatherSoData.temperatureInCelsius = _weatherData.main.temp.ToCelsius();
                        weatherSoData.temperatureInFahrenheit = _weatherData.main.temp.ToFahrenheit();
                        weatherSoData.sunriseTime = _weatherData.sys.sunrise.ToDateTime();
                        weatherSoData.sunsetTime = _weatherData.sys.sunset.ToDateTime();

                        // Log data (optional)
                        Debug.Log($"Temperature in Celsius: {weatherSoData.temperatureInCelsius}°C");
                        Debug.Log($"Temperature in Fahrenheit: {weatherSoData.temperatureInFahrenheit}°F");
                        Debug.Log($"Sunrise time: {weatherSoData.sunriseTime}");
                        Debug.Log($"Sunset time: {weatherSoData.sunsetTime}");
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