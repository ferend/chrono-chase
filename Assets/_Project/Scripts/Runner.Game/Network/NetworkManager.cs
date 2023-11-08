using System;
using System.Collections;
using _Project.Scripts.Runner.Utilities;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;

namespace _Project.Scripts.Runner.Game.Network
{
    public class NetworkManager : Manager
    {
        [SerializeField] private NetworkDataSO networkData;
        [SerializeField] private WeatherSO weatherData;
       
        public UnityAction OnFetchWeatherData; 
        public VoidEventChannelSO NetworkEventChannel;

        public override void Setup() => NetworkEventChannel.OnEventRaised += FetchRoutine;

        private void FetchRoutine() => StartCoroutine(FetchWeatherData());

        private IEnumerator FetchWeatherData()
        {
            yield return new WaitForSeconds(1f);

            string url = $"https://api.openweathermap.org/data/2.5/weather?q={weatherData.cityName}&appid={networkData.apiKey}";
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
                        weatherData.temperatureInCelsius = _weatherData.main.temp.ToCelsius();
                        weatherData.temperatureInFahrenheit = _weatherData.main.temp.ToFahrenheit();
                        weatherData.sunriseTime = _weatherData.sys.sunrise.ToDateTime();
                        weatherData.sunsetTime = _weatherData.sys.sunset.ToDateTime();
                        weatherData.currentTime = _weatherData.dt.ToDateTime();
            
                        // Log data (optional)
                        Debug.Log($"Temperature in Celsius: {weatherData.temperatureInCelsius}°C");
                        Debug.Log($"Temperature in Fahrenheit: {weatherData.temperatureInFahrenheit}°F");
                        Debug.Log($"Sunrise time: {weatherData.sunriseTime}");
                        Debug.Log($"Sunset time: {weatherData.sunsetTime}");
                        Debug.Log($"Time {weatherData.currentTime}");
                        
                        OnFetchWeatherData?.Invoke();
                        
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