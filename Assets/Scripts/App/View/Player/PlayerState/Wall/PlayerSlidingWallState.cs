using App.Base;
using UnityEngine;

namespace App.View
{
    public class PlayerSlidingWallState : BasePlayerState
    {
        public PlayerSlidingWallState(BaseRole role, BaseStateMachine stateMachine, string argsName) : base(role, stateMachine, argsName)
        {
        }

        public override void Enter()
        {
            base.Enter();

            // set direction to wall dir
            if (player.wallDir == 1)
            {
                player.SetDir(1);
            }
            else
            {
                player.SetDir(-1);
            }
        }

        public override void Update()
        {
            base.Update();
            
            player.SetVelocity(rg.velocity.x, rg.velocity.y * player.slidingWallSpeed);
            
            if (player.DetectGround())
            {
                machine.ChangeState(machine.IdleState);  
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                machine.isJumpFromWall = true;
                machine.ChangeState(machine.JumpingState);
            }
        }


        protected override void Flip()
        {
            // can not flip
            
        }

        public override void Exit()
        {
            base.Exit();
            // change direction cover to wall dir
            if (player.wallDir == 1)
            {
                player.SetDir(-1);
            }
            else
            {
                player.SetDir(1);
            }
        }
    }
}