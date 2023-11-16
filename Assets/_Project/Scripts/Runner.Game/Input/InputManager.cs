using System;
using System.Collections;
using UnityEngine;

namespace Assets._Project.Scripts.Runner.Game.Input
{
    public class InputManager : MonoBehaviour
    {
        // Adjust this speed to control the movement speed
        public float moveSpeed = 5f;
        public Swipe swipe;
        public Rigidbody rb;
        
        private void Start()
        {
            swipe.OnSwipe += OnSwiped;
        }


        private void OnSwiped(Swipe.GestureData pos)
        {
            rb.velocity = pos.rawDirection.normalized * moveSpeed;
        }

     
    }
}