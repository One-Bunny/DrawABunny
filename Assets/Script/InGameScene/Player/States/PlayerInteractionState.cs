using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OneBunny {

    [FSMState((int)Player.States.Interaction)]
    public class PlayerInteractionState : FSMState<Player>
    {
        #region Runner

        public PlayerInteractionState(IFSMRunner runner) : base(runner)
        {

        }

        #endregion


    }

}