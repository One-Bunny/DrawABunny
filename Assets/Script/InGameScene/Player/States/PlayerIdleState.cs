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

        private Vector2 playerMovement = Vector2.zero;

        public override void BeginState()
        {
            runnerEntity.SetAction(Player.ButtonActions.Jump, OnJump);

            runnerEntity.OnMove = (x) => playerMovement = x;

            runnerEntity.playerSkeletonAnimation.AnimationState.SetAnimation(0, "P_Default_Animastion", true);
        }

        public override void UpdateState()
        {
            if (playerMovement != Vector2.zero)
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
