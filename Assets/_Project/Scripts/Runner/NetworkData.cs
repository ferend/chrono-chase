using UnityEngine;

namespace _Project.Scripts.Runner
{
    [CreateAssetMenu(fileName = "NetworkData", menuName = "NetworkData/Network")]
    public class NetworkData : ScriptableObject
    {
        public string apiKey = "";
    }
}