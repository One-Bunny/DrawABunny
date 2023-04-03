using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OneBunny
{
    public partial class Player : FSMRunner<Player>, IFSMRunner
    {
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
        }

        protected override void FixedUpdate()
        {
            base.FixedUpdate();
        }

    }
}
