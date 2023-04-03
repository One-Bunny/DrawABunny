using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace OneBunny {
    [FSMState((int)Player.States.Idle)]
    public class PlayerIdleState : FSMState<Player>
    {
        #region Runner
        
        public PlayerIdleState(IFSMRunner runner) : base(runner)
        {

        }

        #endregion
    
    }
}
