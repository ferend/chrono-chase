using System;
using UnityEngine;

namespace _Project.Scripts.Runner
{
    [CreateAssetMenu(fileName = "NetworkData", menuName = "NetworkData/Network")]
    public class NetworkDataSO : ScriptableObject
    {
        public string apiKey = "";
    }
}