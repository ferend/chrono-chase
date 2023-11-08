using System;
using UnityEngine;

namespace _Project.Scripts.Runner
{
    [CreateAssetMenu(fileName = "Weather", menuName = "NetworkData/Weather")]

    public class WeatherSO : ScriptableObject
    {
        public string cityName;
        public float temperatureInCelsius;
        public float temperatureInFahrenheit;
        public DateTime sunriseTime;
        public DateTime sunsetTime;
        public DateTime currentTime;

        private void OnDisable()
        {
            cityName = "";
        }
    }
}
