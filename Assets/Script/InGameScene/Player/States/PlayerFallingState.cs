using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OneBunny {
    [FSMState((int)Player.States.Falling)]
    public class PlayerFallingState : FSMState<Player>
    {
        #region Runner
        public PlayerFallingState(IFSMRunner runner) : base(runner)
        {

        }

        #endregion

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
