using App.Base;
using UnityEngine;

namespace App.View
{
    public class BasePlayerState : BaseState
    {
        protected float xAxis;
        protected float yAxis;

        protected Player player => (Player)role;
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
            InputDash();
            InputAttack();
            InputClimbLadder();

            if (machine.CurrentState == machine.FallingState && rg.velocity.y == 0)
            {
                machine.ChangeState(machine.IdleState);
            }
        }

        public override void Exit()
        {
            base.Exit();
            player.animationFinish = true;
        }

        protected virtual void InputClimbLadder()
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                if (!machine.isClimbing && player.DetectLadder())
                {
                    player.DetectLadder(callBack: (ladderHit) =>
                    {
                        // set player position to ladder position
                        player.transform.position =
                            new Vector3(ladderHit.transform.position.x, player.transform.position.y, player.transform.position.z);
                    });
                    machine.ClimbLadderState.up = true; // set climb dir
                    machine.ChangeState(machine.ClimbLadderState);
                }
            }

            if (Input.GetKeyDown(KeyCode.S) && !player.DetectGround())
            {
                if (!machine.isClimbing && player.DetectLadder(1f))
                {
                    machine.ClimbLadderState.up = false;
                    machine.ChangeState(machine.ClimbLadderState);

                    player.DetectLadder(1f, (ladderHit) =>
                    {
                        player.transform.position = new Vector3(ladderHit.transform.position.x, player.transform.position.y - 0.15f,
                            player.transform.position.z);
                    });
                }
            }
        }

        protected virtual void InputAttack()
        {
            if (Input.GetMouseButtonDown(0) && player.DetectGround())
            {
                if (machine.AttackState.attacking) return;

                // dash attack
                if (machine.isDashing)
                {
                    machine.AttackState.dashAttack = true;
                }

                machine.ChangeState(machine.AttackState);
            }
        }

        protected virtual void InputDash()
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