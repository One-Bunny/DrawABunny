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
    }
}