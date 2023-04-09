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

        private Vector2 movement;
        private readonly string moveAnimationName = "P_Move_Animation";

        public override void BeginState()
        {
            runnerEntity.SetAction(Player.ButtonActions.Jump, OnJump);
            runnerEntity.OnMove = (x) => movement = x;

            runnerEntity.skeletonAnimation.AnimationState.SetAnimation(0, moveAnimationName, true);
        }

        public override void UpdateState()
        {
            if (movement == Vector2.zero)
            {
                runnerEntity.ChangeState(Player.States.Idle);
            }
        }

        public override void FixedUpdateState()
        {

            var velocity = Vector2.zero;

            velocity.x = movement.x * runnerEntity.statusData.moveSpeed;
            velocity.y = runnerEntity.rigidbody.velocity.y;

            runnerEntity.rigidbody.velocity = velocity;

            runnerEntity.skeletonAnimation.skeleton.ScaleX
                = movement.x < 0 ? -1f : 1f;
        }

        public override void ExitState()
        {
            runnerEntity.OnMove = null;
            runnerEntity.rigidbody.velocity = Vector2.zero;
        }

        private void OnJump(bool isOnJump)
        {
            if (isOnJump)
            {
                runnerEntity.ChangeState(Player.States.Jump);
            }
        }

    }

}