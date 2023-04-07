using UnityEngine;


namespace OneBunny
{
    [FSMState((int)Player.States.Idle)]
    public class PlayerIdleState : FSMState<Player>
    {
        #region Runner

        public PlayerIdleState(IFSMRunner runner) : base(runner)
        {

        }

        #endregion

        private Vector2 movement = Vector2.zero;

        public override void BeginState()
        {
            runnerEntity.SetAction(Player.ButtonActions.Jump, OnJump);

            runnerEntity.OnMove = (x) => movement = x;

            runnerEntity.skeletonAnimation.AnimationState.SetAnimation(0, runnerEntity.idleAnimationName, true);
        }

        public override void UpdateState()
        {
            if (movement != Vector2.zero)
            {
                runnerEntity.ChangeState(Player.States.Move);
            }
        }


        public override void ExitState()
        {
            runnerEntity.OnMove = null;
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
