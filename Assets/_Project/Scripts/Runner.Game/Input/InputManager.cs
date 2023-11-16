
using UnityEngine;

namespace _Project.Scripts.Runner.Game.Input
{
    public class InputManager : Manager
    {
        [SerializeField] private Swipe swipe;
        [SerializeField] private GestureEventChannel onLaneChangeRequest;

        private void Start()
        {
            swipe.OnSwipe += OnSwiped;
        }


        private void OnSwiped(Swipe.GestureData gesture)
        {
            onLaneChangeRequest?.RaiseEvent(gesture);
        }

     
    }
}