using Spine.Unity;
using UnityEngine;

namespace OneBunny
{
    public partial class Player : FSMRunner<Player>, IFSMRunner
    {
        [field: SerializeField] public Rigidbody2D rigidbody { get; private set; }
        public PlayerStatusData statusData;
        public bool isGrounded { get; private set; }

        public SkeletonAnimation skeletonAnimation;
        public enum States : int
        {
            Start,

            Idle,
            Move,
            Jump,
            Falling,
            Interaction,

            End
        }

        #region AnimationNames
        public readonly string idleAnimationName = "P_Default_Animastion";
        public readonly string moveAnimationName = "P_Move_Animation";
        public readonly string jumpAnimationName = "p_Jump_animation";
        public readonly string fallingAnimationName = "p_fall_animation";
        #endregion

        private void Awake()
        {
            InitInputs();
            SetUp(States.Idle);
        }

        protected override void Update()
        {
            base.Update();

            UpdateInputs();
        }

        protected override void FixedUpdate()
        {
            base.FixedUpdate();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.contacts[0].normal.y > 0.7f)
            {
                isGrounded = true;
            }
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            isGrounded = false;
        }
    }
}
