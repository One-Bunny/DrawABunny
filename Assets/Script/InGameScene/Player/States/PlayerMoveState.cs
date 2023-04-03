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

    }

}