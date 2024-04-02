using App.Base;
using UnityEngine;

namespace App.View.Wall
{
    public class PlayerHangOnWallState: BasePlayerState
    {
        public PlayerHangOnWallState(BaseRole role, BaseStateMachine stateMachine, string argsName) : base(role, stateMachine, argsName)
        {
        }

        public override void Enter()
        {
            base.Enter();
            
            rg.gravityScale = 0;
            rg.AddForce(Vector2.right * (player.dir * 10f));
        }

        public override void Update()
        {
            base.Update();
            
            player.SetVelocity(rg.velocity.x,0);
            
            // allow to jump from wall
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (player.wallDir != player.dir)
                {
                    // wall dir is opposite to player dir then jump from wall
                    player.isJumpFromWall = true;
                    machine.ChangeState(machine.JumpingState);
                }
                else
                {
                    // climb up the wall
                    machine.ChangeState(machine.ClimbState);
                }
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                machine.ChangeState(machine.SlidingWallState);
            }
        }

        public override void Exit()
        {
            base.Exit();
            
            rg.gravityScale = 1;
            
            // flip when exit
            ExitFlip();
        }

        protected override void InputDash()
        {
            // do not dash when hanging on wall
        }

        protected override void Flip()
        {
            // do not flip when hanging on wall
            // but allow to change direction
            if (xAxis > 0)
            {
                player.dir = 1;
            }
            else if (xAxis < 0)
            {
                player.dir = -1;
            }
        }

        private void ExitFlip()
        {
            if (player.dir == 1)
            {
                player.transform.rotation = Quaternion.Euler(0,0,0);
            }
            else if (player.dir == -1)
            {
                player.transform.rotation = Quaternion.Euler(0,-180,0);
            }
        }
    }
}