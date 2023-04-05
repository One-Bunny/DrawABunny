using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OneBunny
{
    [FSMState((int)Player.States.Move)]
    public class PlayerMoveState : FSMState<Player>
    {
        #region Runner

        public PlayerMoveState(IFSMRunner runner) : base(runner)
        {

        }

        #endregion

        private Vector2 playerMovement;

        public override void BeginState()
        {
            runnerEntity.OnMove = (x) => playerMovement = x;

            //var velocity = runnerEntity.playerRigidbody.velocity;
            //velocity.x = playerMovement.x * runnerEntity.playerStatusData.moveSpeed;
        }

        public override void UpdateState()
        {
            if (playerMovement == Vector2.zero)
            {
                runnerEntity.ChangeState(Player.States.Idle);
            }
        }

        public override void FixedUpdateState() 
        {

            var velocity = Vector2.zero;
            
            velocity.x=playerMovement.x * runnerEntity.playerStatusData.moveSpeed;
            velocity.y = runnerEntity.playerRigidbody.velocity.y;

            runnerEntity.playerRigidbody.velocity = velocity;
        }

        public override void ExitState()
        {
            runnerEntity.OnMove = null;
            runnerEntity.playerRigidbody.velocity = Vector2.zero;
        }

        private void OnJump(bool isOnJump){
            if (isOnJump)
            {
                runnerEntity.ChangeState(Player.States.Jump);
            }
        }

    }

}