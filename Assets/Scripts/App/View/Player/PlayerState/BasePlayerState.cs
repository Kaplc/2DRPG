using App.Base;
using UnityEngine;

namespace App.View
{
    public class BasePlayerState: BaseState
    {
        protected float xAxis;
        protected float yAxis;

        protected Player player => (Player) role;
        protected new PlayerStateMachine machine => base.machine as PlayerStateMachine;

        protected float timer;

        public BasePlayerState(BaseRole role, BaseStateMachine stateMachine, string argsName) : base(role, stateMachine, argsName)
        {
        }

        public override void Enter()
        {
            base.Enter();
            
            // reset animation finish
            player.animationFinish = false;
        }

        public override void Update()
        {
            base.Update();
            
            xAxis = Input.GetAxisRaw("Horizontal");
            yAxis = Input.GetAxisRaw("Vertical");
            machine.animator.SetFloat("yVelocity", rg.velocity.y);
            
            Flip();
            InputAttack();
            InputDash();
        }

        private void InputAttack()
        {
            if (Input.GetMouseButtonDown(0) && player.DetectGround())
            {
                if (machine.AttackState.attacking) return;

                // dash attack
                if (player.isDashing)
                {
                    machine.AttackState.dashAttack = true;
                }

                machine.ChangeState(machine.AttackState);
            }
        }
        
        private void InputDash()
        {
            if (Input.GetKeyDown(KeyCode.LeftShift) && player.dashCdTimer < 0)
            {
                if (player.DetectWall())
                {
                    return;
                }
                // is running can down dash
                if (Input.GetKey(KeyCode.S) && player.DetectGround() && machine.CurrentState == machine.RunState)
                {
                    machine.ChangeState(machine.PlayerDownDashState);
                }
                else
                {
                    machine.ChangeState(machine.DashState);
                }
                player.dashCdTimer = player.dashCd;
            }
            else
            {
                player.dashCdTimer -= Time.deltaTime;
            }
        }

        protected virtual void Flip()
        {
            if (xAxis > 0)
            {
                player.transform.rotation = Quaternion.Euler(0, 0, 0);
                player.dir = 1;
            }
            else if (xAxis < 0)
            {
                player.transform.rotation = Quaternion.Euler(0, 180, 0);
                player.dir = -1;
            }
        }
    }
}