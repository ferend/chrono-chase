using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace _Project.Scripts.Runner
{
    [CreateAssetMenu(menuName = "Events/ Event Channel", fileName = "EventChannelSO")]
    public class EventChannel : ScriptableObject
    {
        private readonly List<GameEventListener> _eventListeners = new List<GameEventListener>();

        public void Raise()
        {
            for (int i = _eventListeners.Count -1; i >= 0; i--)
            {
                _eventListeners[i].OnEventRaised();
            }
        }

        public void RegisterListener(GameEventListener listener)
        {
            if (!_eventListeners.Contains(listener))
            {
                _eventListeners.Add(listener);
            }
        }

        public void UnregisterListener(GameEventListener listener)
        {
            if (_eventListeners.Contains(listener))
            {
                _eventListeners.Remove(listener);
            }
        }
    }
}