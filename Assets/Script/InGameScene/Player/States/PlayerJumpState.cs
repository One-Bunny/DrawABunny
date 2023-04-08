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

        private Vector2 _movement;
        private Vector2 velocity;
        private readonly string jumpAnimationName = "p_Jump_animation";
        public override void BeginState()
        {
            runnerEntity.OnMove = (x) => _movement = x;

            velocity = Vector2.zero;
            velocity.x = _movement.x * runnerEntity.statusData.moveSpeed;
            velocity.y = runnerEntity.statusData.jumpPower;

            runnerEntity.rigidbody.velocity = velocity;
            runnerEntity.skeletonAnimation.AnimationState.SetAnimation(0, jumpAnimationName, false);
        }

        public override void FixedUpdateState()
        {
            velocity.x = _movement.x * runnerEntity.statusData.moveSpeed;
            velocity.y = runnerEntity.rigidbody.velocity.y;

            if (runnerEntity.rigidbody.velocity.y <= 0)
            {
                runnerEntity.ChangeState(Player.States.Falling);
            }

            runnerEntity.rigidbody.velocity = velocity;

            runnerEntity.skeletonAnimation.skeleton.ScaleX
                = _movement.x < 0 ? -1f : 1f;
        }

        public override void ExitState()
        {
            runnerEntity.OnMove = null;
            runnerEntity.ClearAction(Player.ButtonActions.Jump);
        }
    }
}