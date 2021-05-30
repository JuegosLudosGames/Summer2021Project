using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace summer2021.csharp.game.character
{
    //Added by Kyle | May 30, 2021
    [RequireComponent(typeof(Rigidbody2D))]
    public class CharacterController : MonoBehaviour
    {

        [SerializeField] private float Speed = 10.0f;
        [SerializeField] private float SmoothingConstant = 0.05f;
        [SerializeField] private float JumpForce = 400f;

        private float PreviousMovementInput = 0;
        private bool PreviousJumpInput = false;
        private bool PreviousJumpConsideredInput = false;

        //component ref
        private Rigidbody2D Rigidbody;
        private Vector2 Current_Velocity = Vector2.zero;

        private void Start() {
            Rigidbody = GetComponent<Rigidbody2D>();
        }

        private void Update() {
            Vector2 TargetV = new Vector2(PreviousMovementInput * Speed, Rigidbody.velocity.y);

            //set velocity
            Rigidbody.velocity = Vector2.SmoothDamp(Rigidbody.velocity, TargetV, ref Current_Velocity, SmoothingConstant);

            //jumping
            if(PreviousJumpInput && !PreviousJumpConsideredInput) {

                Rigidbody.AddForce(new Vector2(0f, JumpForce));

                PreviousJumpConsideredInput = true;
            } else if(!PreviousJumpInput && PreviousJumpConsideredInput) {
                PreviousJumpConsideredInput = false;
            }
        }

        public void onMovementChange(InputAction.CallbackContext context) => PreviousMovementInput = context.ReadValue<float>();
        public void onJumpChange(InputAction.CallbackContext context) => PreviousJumpInput = context.ReadValueAsButton();

    }
}