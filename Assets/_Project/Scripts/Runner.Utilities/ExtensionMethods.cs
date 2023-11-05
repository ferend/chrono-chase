using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace _Project.Scripts.Runner.Utilities
{
    public static class ExtensionMethods 
    {
        
        public static Vector3 Round(this Vector3 v)
        {
            v.x = Mathf.Round(v.x);
            v.y = Mathf.Round(v.y);
            v.z = Mathf.Round(v.z);

            return v;
        }
        
        
        public const float TAU = 6.28318530718f;
        

        // So we can use the null-propagation operator with Unity objects
        public static T Ref<T>( this T obj ) where T : Object {
            return obj == null ? null : obj;
        }
        
        public static float ToCelsius(this float kelvin)
        {
            return kelvin - 273.15f;
        }

        public static float ToFahrenheit(this float kelvin)
        {
            return (kelvin - 273.15f) * 9 / 5 + 32;
        }
        
        public static DateTime ToDateTime(this int unixTimestamp)
        {
            return DateTimeOffset.FromUnixTimeSeconds(unixTimestamp).DateTime;
        }
        
        public static float AspectRatio( this Texture texture ) {
            return texture.width / texture.height;
        }
    }
}
