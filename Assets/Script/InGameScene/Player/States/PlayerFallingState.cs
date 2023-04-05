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

        private bool _isFalling = false;

        private Vector2 playerMovement;

        public override void BeginState()
        {
            runnerEntity.OnMove = (x) => playerMovement = x;

            var velocity = Vector2.zero;
            velocity.x = playerMovement.x * runnerEntity.playerStatusData.moveSpeed;
            velocity.y = runnerEntity.playerRigidbody.velocity.y;
            runnerEntity.playerRigidbody.velocity = velocity;
            runnerEntity.playerSkeletonAnimation.AnimationState.SetAnimation(0, "p_fall_animation", false);
        }

        public override void FixedUpdateState()
        {
            if (runnerEntity.isGrounded)
            {
                runnerEntity.ChangeState(Player.States.Move);
            }

            var velocity = Vector2.zero;

            velocity.x = playerMovement.x * runnerEntity.playerStatusData.moveSpeed;
            velocity.y = runnerEntity.playerRigidbody.velocity.y*1.1f;

            runnerEntity.playerRigidbody.velocity = velocity;

            runnerEntity.playerSkeletonAnimation.skeleton.ScaleX 
                = playerMovement.x < 0 ? -1f : 1f;
        }

        public override void ExitState()
        {
            runnerEntity.OnMove = null;
        }
    }
}