using System;
using UnityEngine;

namespace App.View
{
    public class Player : BaseRole
    {
        #region move info

        [Header("Move Args")] public float runSpeed;
        public float yVelocity;
        public float jumpForce;

        [Header("Dash Args")] public float dashCd;
        [HideInInspector] public float dashCdTimer;
        public float dashDuration;
        public float dashSpeed;
        public float dashingFallingSpeed;
        public float downDashDuration;
        [HideInInspector] public bool isDashing;

        #region attack

        [Header("Attack Args")] public float attackWindowTime;
        [HideInInspector] public int attackCount;
        [HideInInspector] public bool attacking;

        #endregion

        #endregion

        #region animation

        private PlayerStateMachine StateMachine { get; set; }
        [HideInInspector] public bool animationFinish;

        #endregion

        #region detect

        public Transform hangOnWallDetect;
        public float hangOnWallDetectDistance;
        private RaycastHit2D hangOnWallHit; 

        #endregion

        public override void Awake()
        {
            base.Awake();

            StateMachine = new PlayerStateMachine(this, animator);
        }

        public override void Start()
        {
            base.Start();

            StateMachine.Initialize(StateMachine.IdleState);
        }

        public override void Update()
        {
            base.Update();

            StateMachine.CurrentState.Update();
            
            DetectHangOnWall();
        }

        #region gizmos

        protected override void OnDrawGizmos()
        {
            base.OnDrawGizmos();
            
            // hang on wall gizmos
            Gizmos.color = Color.red;
            var hangOnWallPos = hangOnWallDetect.position;
            Gizmos.DrawLine(hangOnWallPos, hangOnWallPos + new Vector3(hangOnWallDetectDistance * dir, 0, 0));
        }

        #endregion
        
        #region velocity

        public void SetVelocity(float x, float y)
        {
            rg.velocity = new Vector2(x, y);
        }

        #endregion

        #region detect


        private void DetectHangOnWall()
        {
            if (StateMachine.CurrentState == StateMachine.HangOnWallState)
            {
                // set player y equal to hit point y
                transform.position = new Vector3(transform.position.x, hangOnWallHit.transform.position.y - 0.203f, transform.position.z);
                return;
            }
            
            hangOnWallHit = Physics2D.Raycast(hangOnWallDetect.position, new Vector3(hangOnWallDetectDistance * dir, 0, 0), hangOnWallDetectDistance, 1 << LayerMask.NameToLayer("Ground"));
            if (hangOnWallHit.collider is not null && hangOnWallHit.collider.gameObject.CompareTag("HangOnWallPos"))
            {
                // 
                StateMachine.ChangeState(StateMachine.HangOnWallState);
               
            }
        }
        

        #endregion

        #region Animation

        public void AnimationFinishTrigger()
        {
            // playing animation finish
            animationFinish = true;
        }

        #endregion
    }
}