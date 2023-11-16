using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace _Project.Scripts.Runner
{
    public abstract class GenericEventChannel<T> : ScriptableObject
    {
        [Tooltip("The action to perform; Listeners subscribe to this UnityAction")]
        public UnityAction<T> OnEventRaised;

        public void RaiseEvent(T parameter)
        {

            if (OnEventRaised == null)
                return;

            OnEventRaised.Invoke(parameter);

        }
    }

}