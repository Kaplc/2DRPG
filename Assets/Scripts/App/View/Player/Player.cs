using System;
using UnityEngine;

namespace App.View
{
    public class Player : BaseRole
    {
        [Header("Now State")] public int dir;

        #region move info

        [Header("Move Args")] public float runSpeed;
        public float yVelocity;
        public float jumpForce;

        [Header("Dash Args")] public float dashCd;
        [HideInInspector] public float dashCdTimer;
        public float dashDuration;
        public float dashSpeed;
        public float dashingFallingSpeed;

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

            InputDash();

            // if (Input.GetMouseButtonDown(0))
            // {
            //     if (!attacking)
            //     {
            //         StateMachine.ChangeState(StateMachine.AttackState);
            //     }
            // }
        }

        private void InputDash()
        {
            if (Input.GetKeyDown(KeyCode.LeftShift) && dashCdTimer < 0)
            {
                dashCdTimer = dashCd;
                StateMachine.ChangeState(StateMachine.DashState);
            }
            else
            {
                dashCdTimer -= Time.deltaTime;
            }
        }

        #region velocity

        public void SetVelocity(float x, float y)
        {
            rg.velocity = new Vector2(x, y);
        }

        #endregion

        #region detect

        public bool DetectGround()
        {
            RaycastHit2D hit = Physics2D.Raycast(groundDetect.position, Vector2.down, groundDetectDistance, 1 << LayerMask.NameToLayer("Ground"));
            if (hit.collider != null)
            {
                return true;
            }

            return false;
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