using App.Base;
using UnityEngine;

namespace App.View.Climb
{
    public class PlayerClimbLadderState : BasePlayerState
    {
        private float groundY;
        private float heightFromGround = 0.03f;
        private bool canDetectGround;
        public bool up;

        public PlayerClimbLadderState(BaseRole role, BaseStateMachine stateMachine, string argsName) : base(role, stateMachine, argsName)
        {
        }

        public override void Enter()
        {
            base.Enter();

            machine.isClimbing = true;
            rg.gravityScale = 0;
            // set dir to 0
            player.dir = 0;
            groundY = player.transform.position.y;
            canDetectGround = false;
            
            // 
            if (!up)
            {
                player.roleCollider.isTrigger = true;
            }
        }

        public override void Update()
        {
            base.Update();

            if (yAxis > 0)
            {
                // update dir
                up = true;
                player.SetVelocity(0, yAxis * player.climbLadderSpeed);
                machine.animator.StopPlayback();
                machine.animator.speed = 1;
            }
            else if (yAxis < 0)
            {
                up = false;
                player.SetVelocity(0, yAxis * player.climbLadderSpeed);
                machine.animator.StartPlayback();
                machine.animator.speed = -1;
            }
            else
            {
                player.SetVelocity(rg.velocity.x, 0);
                machine.animator.StopPlayback();
                machine.animator.speed = 0;
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                machine.isJumpFromWall = true;
                machine.ChangeState(machine.JumpingState);
            }

            if (up)
            {
                if (!player.DetectLadder())
                {
                    machine.ChangeState(machine.IdleState);
                }
            }
            else
            {
                if (player.DetectGround())
                {
                    machine.ChangeState(machine.IdleState);
                }
            }
        }

        public override void Exit()
        {
            base.Exit();

            machine.isClimbing = false;
            machine.animator.speed = 1;
            rg.gravityScale = 1;
            
            machine.animator.StopPlayback();
            
            player.roleCollider.isTrigger = false;
            
            // flip player
            if (player.dir > 0)
            {
                player.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else if (player.dir < 0)
            {
                player.transform.rotation = Quaternion.Euler(0, 180, 0);
            }
        }

        protected override void InputDash()
        {
            // do not dash when climbing ladder
        }

        protected override void Flip()
        {
            if (xAxis > 0)
            {
                player.dir = 1;
            }
            else if (xAxis < 0)
            {
                player.dir = -1;
            }
        }
    }
}