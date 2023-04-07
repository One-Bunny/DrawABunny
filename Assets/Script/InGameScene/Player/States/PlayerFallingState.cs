using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OneBunny
{
    [FSMState((int)Player.States.Falling)]
    public class PlayerFallingState : FSMState<Player>
    {
        #region Runner 
        public PlayerFallingState(IFSMRunner runner) : base(runner)
        {

        }

        #endregion

        private Vector2 movement;

        public override void BeginState()
        {
            runnerEntity.OnMove = (x) => movement = x;

            var velocity = Vector2.zero;
            velocity.x = movement.x * runnerEntity.statusData.moveSpeed;
            velocity.y = runnerEntity.rigidbody.velocity.y;
            runnerEntity.rigidbody.velocity = velocity;
            runnerEntity.skeletonAnimation.AnimationState.SetAnimation(0, runnerEntity.fallingAnimationName, false);
        }

        public override void FixedUpdateState()
        {
            if (runnerEntity.isGrounded)
            {
                runnerEntity.ChangeState(Player.States.Move);
            }

            var velocity = Vector2.zero;

            velocity.x = movement.x * runnerEntity.statusData.moveSpeed;
            velocity.y = runnerEntity.rigidbody.velocity.y*1.1f;

            runnerEntity.rigidbody.velocity = velocity;

            runnerEntity.skeletonAnimation.skeleton.ScaleX 
                = movement.x < 0 ? -1f : 1f;
        }

        public override void ExitState()
        {
            runnerEntity.OnMove = null;
        }
    }
}