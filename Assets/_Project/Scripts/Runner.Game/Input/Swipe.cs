using System;
using UnityEngine;
using UnityEngine.InputSystem;


public enum InputType
{
    Button = 0,
    Swipe = 1,
    All = 2
}

namespace _Project.Scripts.Runner.Game.Input
{
    [CreateAssetMenu(menuName = "Create Swipe", fileName = "Swipe", order = 0)]
    public class Swipe : ScriptableObject

    {
        [Serializable]
        public struct GestureData
        {
            public Vector2Int clampedDirection;
            public Vector2 rawDirection;
            public float duration;
            public Vector2 _initialPosition;

            public GestureData(Vector2Int clampedDirection, Vector2 rawDirection, float duration, Vector2 initialPosition)
            {
                this.clampedDirection = clampedDirection;
                this.rawDirection = rawDirection;
                this.duration = duration;
                _initialPosition = initialPosition;
            }
        }

        public event Action<GestureData> OnSwipe;

        [Space]
        [SerializeField] private float minDuration;
        [SerializeField] private float minDistance;
        [SerializeField] private float maxDistance;
        [SerializeField] private float deadZone;


        private Vector2 _traveled;
        private Vector2Int _lastDirection;
        private float _startTime;
        private Vector2 _startPosition;

        private GameInput _input;

        private void OnEnable()
        {
            if(_input == null)
            {
                _input = new GameInput();
            }
            
            _input.PlayerControls.Enable();


            _input.PlayerControls.OnPrimaryTouch.started += TouchStart;
            _input.PlayerControls.OnPrimaryTouch.canceled += TouchEnd;
            _input.PlayerControls.PrimaryTouchPosition.performed += TouchStartPosition;
            _input.PlayerControls.TouchDelta.started += TouchUpdate;

        }

        private void OnDisable()
        {
            if(_input!= null) _input.PlayerControls.Disable();

        }


        private void TouchStart(InputAction.CallbackContext context)
        {
            _traveled = Vector2.zero;
            _startTime = Time.time;

        }

        private void TouchStartPosition(InputAction.CallbackContext context)
        {
            
               _startPosition = context.ReadValue<Vector2>();
            
        }

        private void TouchUpdate(InputAction.CallbackContext context)
        {
            _traveled += context.ReadValue<Vector2>();
        }

        private void TouchEnd(InputAction.CallbackContext context)
        {
            float duration = Time.time - _startTime;

            if (duration < minDuration )
            {
                return;
            }

            float d = Mathf.Abs(_traveled.normalized.x) - Mathf.Abs(_traveled.normalized.y);

            if (d < -deadZone)
            {
                _lastDirection = new Vector2Int(0, (int)(Mathf.Ceil(Mathf.Abs(_traveled.normalized.x)) * Mathf.Sign(_traveled.normalized.y)));
                OnSwipe?.Invoke(new GestureData(_lastDirection, _traveled, duration, _startPosition));

                return;
            }

            if (d > deadZone)
            {
                _lastDirection = new Vector2Int((int)(Mathf.Ceil(Mathf.Abs(_traveled.normalized.x)) * Mathf.Sign(_traveled.normalized.x)), 0);
                OnSwipe?.Invoke(new GestureData(_lastDirection, _traveled, duration, _startPosition));
            }
        }

    }
}
