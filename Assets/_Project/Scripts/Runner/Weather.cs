using System;
using UnityEngine;

namespace _Project.Scripts.Runner
{
    [CreateAssetMenu(fileName = "Weather", menuName = "NetworkData/Weather")]

    public class Weather : ScriptableObject
    {
        public float temperatureInCelsius;
        public float temperatureInFahrenheit;
        public DateTime sunriseTime;
        public DateTime sunsetTime;
    }
}
