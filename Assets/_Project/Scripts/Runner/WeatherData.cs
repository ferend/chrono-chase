using System;
using UnityEngine;

namespace _Project.Scripts.Runner
{
    [global::System.Serializable]
    public class WeatherData
    {
        public MainData main;
        public int dt;
        public SysData sys;
    }

    [global::System.Serializable]
    public class MainData
    {
        public float temp;

    }

    [global::System.Serializable]
    public class SysData
    {
        public int sunrise;
        public int sunset;
    }
}