using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

namespace OneBunny
{
    public partial class Player : FSMRunner<Player>, IFSMRunner
    {
        [field:SerializeField] public Rigidbody2D playerRigidbody { get; private set;}
        public PlayerStatusData playerStatusData;
        public bool isGrounded { get; private set; }
        private bool formerIsGrounded;

        public SkeletonAnimation playerSkeletonAnimation;
        public enum States : int
        {
            Start,

            Idle,
            Move,
            Jump,
            Falling,
            Interaction,

            End
        }

        private void Awake()
        {
            InitInputs();
            SetUp(States.Idle);
        }

        protected override void Update()
        {
            base.Update();

            UpdateInputs();
            if (formerIsGrounded != isGrounded)
            {
                Debug.Log(isGrounded);
            }
            formerIsGrounded = isGrounded;
        }

        protected override void FixedUpdate()
        {
            base.FixedUpdate();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.contacts[0].normal.y > 0.7f)
            {
                isGrounded = true;
            }
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            isGrounded = false;
        }
    }
}
