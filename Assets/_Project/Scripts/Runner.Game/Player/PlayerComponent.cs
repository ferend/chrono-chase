using _Project.Scripts.Runner.Game.Input;
using UnityEngine;

namespace _Project.Scripts.Runner.Game.Player
{
    public class PlayerComponent : MonoBehaviour
    {
        private int _lane;

        [SerializeField] private GestureEventChannel onLaneChangeRequest;

        private void OnEnable()
        {
            onLaneChangeRequest.OnEventRaised += ChangeLane;
            Animator animator = this.GetComponent<Animator>();
            animator.SetTrigger("startRun");
        }

        public void ChangeLane(Swipe.GestureData gesture)
        {
            Vector2 direction = gesture.rawDirection.normalized;

            if (direction.x < 0)
            {
                _lane--;
            }
            else
            {
                _lane++;
            }

        }

        private void Update()
        {
            MovePlayer();
        }

        private void MovePlayer()
        {
            if (this.transform != null)
            {
                // Calculate the target position based on the current lane
                Vector3 targetPosition = new Vector3(0, -0.2f, Mathf.Clamp(-_lane * 3, -3, 3));

                // Use Vector3.Lerp to smoothly interpolate between the current position and the target position
                this.transform.position = Vector3.Lerp(this.transform.position, targetPosition, Time.deltaTime * 10);
            }
        }
    }
}

