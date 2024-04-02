using System;
using UnityEngine;

namespace App.View
{
    public class Player : BaseRole
    {
        #region move info

        [Header("Move Args")] public float runSpeed;
        public float yVelocity;
        [Header("Jump Args")]
        public float jumpForce;
        

        [Header("Dash Args")] public float dashCd;
        [HideInInspector] public float dashCdTimer;
        public float dashDuration; 
        public float dashSpeed; 
        public float downDashDuration;
   

        #region attack

        [Header("Attack Args")] public float attackWindowTime;

        #endregion

        #region wall
        [Header("Wall Args")]
        public float slidingWallSpeed;
        [HideInInspector]public int wallDir;

        #endregion

        #endregion

        #region animation

        private PlayerStateMachine StateMachine { get; set; }
        [HideInInspector] public bool animationFinish;

        #endregion

        #region detect
        
        [Header("detect hang on wall Args")]
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

            // init state machine
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
        
        #region set 

        public void SetVelocity(float x, float y)
        {
            rg.velocity = new Vector2(x, y);
        }

        public void SetDir(int dir)
        {
            this.dir = dir;
            if (dir == 1)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
        }

        #endregion

        #region detect


        private void DetectHangOnWall()
        {
            // if player is sliding wall, do not detect hang on wall
            if (StateMachine.CurrentState == StateMachine.SlidingWallState)
            {
                return;
            }
            
            if (StateMachine.CurrentState == StateMachine.HangOnWallState)
            {
                // set player y equal to hit point y
                transform.position = new Vector3(transform.position.x, hangOnWallHit.transform.position.y - 0.203f, transform.position.z);
                return;
            }

            if (StateMachine.isJumpFromWall)
            {
                return;
            }
            
            hangOnWallHit = Physics2D.Raycast(hangOnWallDetect.position, new Vector3(hangOnWallDetectDistance * dir, 0, 0), hangOnWallDetectDistance, 1 << LayerMask.NameToLayer("Ground"));
            if (hangOnWallHit.collider is not null && hangOnWallHit.collider.gameObject.CompareTag("HangOnWallPos"))
            {
                StateMachine.ChangeState(StateMachine.HangOnWallState);
                // set wall dir
                wallDir = dir;
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