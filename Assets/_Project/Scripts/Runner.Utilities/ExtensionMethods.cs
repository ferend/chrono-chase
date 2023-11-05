using UnityEngine;

namespace _Project.Scripts.Runner.Utilities
{
    public static class ExtensionMethods 
    {
        
         public static Color WithAlpha(this Color color, float alpha)
        {
            color.a = alpha;
            return color;
        }

        public static Vector3 Round(this Vector3 v)
        {
            v.x = Mathf.Round(v.x);
            v.y = Mathf.Round(v.y);
            v.z = Mathf.Round(v.z);

            return v;
        }
        public static Quaternion Rotation(float angleA, float angleB, float angleC) =>
            Quaternion.Euler(angleA, angleB, angleC);

        public static Quaternion InverseRotation(Quaternion rot) => Quaternion.Inverse(rot);
    
        private static Matrix4x4 _isoMatrix = Matrix4x4.Rotate(Quaternion.Euler(0, 45, 0));
        public static Vector3 ToIso(this Vector3 input) => _isoMatrix.MultiplyPoint3x4(input);
        
        public const float TAU = 6.28318530718f;
        
        // Returns a normalized vector given an angle in radians, AngToDir
        public static Vector2 GetUnitVectorByAngle( float angRad ) {
            return new Vector2(
                Mathf.Cos( angRad ),
                Mathf.Sin( angRad )
            );
        }
        
        // So we can use the null-propagation operator with Unity objects
        public static T Ref<T>( this T obj ) where T : Object {
            return obj == null ? null : obj;
        }
        
        public static float AtLeast( this float v, float minVal ) => Mathf.Max( v, minVal );
        public static int AtLeast(this int v, int minVal) => Mathf.Max(v, minVal);
        
        public static float ClampAngle (float angle, float min, float max) {
            if (angle < -360f)
                angle += 360f;
            if (angle > 360f)
                angle -= 360f;
            return Mathf.Clamp (angle, min, max);
        }

        public static float InverseLerp(float a, float b, float v) => (v - a) / (b - a);
        
        public static float Lerp(float a, float b, float t) => a + (b - a) * t;
        
        public static float SmoothStep(float value) => value * value * (3 - 2 * value);

        public static bool IsInBounds(int x, int y, int targetX, int targetY)
        {
            return (x >= 0 && x < targetX && y >= 0 && y<targetY);
        }
        
        public static float AspectRatio( this Texture texture ) {
            return texture.width / texture.height;
        }
    }
}
