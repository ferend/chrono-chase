using UnityEngine;

namespace _Project.Scripts.Runner 
{
    public static class PlayerPrefs
    {
        public static void DeleteKey(string key)
        {
            Debug.Log($"PlayerPrefs.DeleteKey(key: {key})");

#if !UNITY_EDITORY && UNIT_WEBGL

        RemoveFromLocalStorage(key: key);
#else
            UnityEngine.PlayerPrefs.DeleteKey(key: key);
#endif
        }

        public static bool HasKey(string key)
        {
            Debug.Log($"PlayerPrefs.HasKey(key: {key})");

#if !UNITY_EDITOR && UNITY_WEBGL
        return (HasKeyInLocalStorage(key) == 1);
#else
            return (UnityEngine.PlayerPrefs.HasKey(key: key));
#endif
        }

        public static string GetString(string key)
        {
            

#if !UNITY_EDITOR && UNITY_WEBGL
        return LoadFromLocalStorage(key: key);
#else
            return (UnityEngine.PlayerPrefs.GetString(key: key));
#endif
        }

        public static void SetString(string key, string value)
        {
            Debug.Log($"PlayerPrefs.SetString(key: {key}, value: {value})");

#if !UNITY_EDITOR && UNITY_WEBGL
        SaveToLocalStorage(key: key, value: value);
#else
            UnityEngine.PlayerPrefs.SetString(key: key, value: value);
#endif
        }

        public static void SetInt(string key, int value)
        {
            Debug.Log($"PlayerPrefs.SetInt(key: {key}, value: {value})");
            // #if !UNITY_EDITOR && UNITY_WEBGL
            // SaveToLocalStorage(key: key, value: value);
            // #else
            UnityEngine.PlayerPrefs.SetInt(key: key, value: value);
            // #endif
        }

        public static int GetInt(string key)
        {
            // #if !UNITY_EDITOR && UNITY_WEBGL
            // return LoadFromLocalStorageInt(key: key);
            // #else
            return (UnityEngine.PlayerPrefs.GetInt(key: key));
            // #endif
        }

        public static void Save()
        {
            Debug.Log(string.Format("PlayerPrefs.Save()"));

#if !UNITY_WEBGL
            UnityEngine.PlayerPrefs.Save();
#endif
        }

#if !UNITY_EDITOR && UNITY_WEBGL
            [DllImport("__Internal")]
            private static extern void SaveToLocalStorage(string key, string value);

            [DllImport("__Internal")]
            private static extern string LoadFromLocalStorage(string key);

            [DllImport("__Internal")]
            private static extern void RemoveFromLocalStorage(string key);

            [DllImport("__Internal")]
            private static extern int HasKeyInLocalStorage(string key);
#endif
    }
}

