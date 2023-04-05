using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OneBunny
{
    [FSMState((int)Player.States.Jump)]
    public class PlayerJumpState : FSMState<Player>
    {
        #region Runner 
        public PlayerJumpState(IFSMRunner runner) : base(runner)
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
            velocity.y = runnerEntity.playerStatusData.jumpPower*0.8f;

            runnerEntity.playerRigidbody.velocity = velocity;
        }

        public override void FixedUpdateState()
        {
            var velocity = Vector2.zero;

            velocity.x = playerMovement.x * runnerEntity.playerStatusData.moveSpeed;
            velocity.y = runnerEntity.playerRigidbody.velocity.y;

            if(runnerEntity.playerRigidbody.velocity.y<=0)
            {
                runnerEntity.ChangeState(Player.States.Falling);
            }

            runnerEntity.playerRigidbody.velocity = velocity;
        }

        public override void ExitState()
        {
            runnerEntity.OnMove = null;
            runnerEntity.ClearAction(Player.ButtonActions.Jump);
        }
    }
}