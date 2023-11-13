using System;
using UnityEngine;
using UnityEngine.Events;

namespace _Project.Scripts.Runner
{
    public class GameEventListener : MonoBehaviour
    {
        public EventChannel Event;
        public UnityEvent Response;
        
        private void OnEnable() => Event.RegisterListener(this);

        private void OnDisable() => Event.UnregisterListener(this);

        public void OnEventRaised() => Response.Invoke();
    }
}