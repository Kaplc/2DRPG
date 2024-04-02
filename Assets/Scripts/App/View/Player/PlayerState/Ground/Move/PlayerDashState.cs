using App.Base;
using UnityEngine;

namespace App.View
{
    public class PlayerDashState : BasePlayerState
    {
        private float durationTimer;

        public PlayerDashState(BaseRole role, BaseStateMachine stateMachine, string argsName) : base(role, stateMachine, argsName)
        {
        }

        public override void Enter()
        {
            base.Enter();

            durationTimer = player.dashDuration;
            
            machine.isDashing = true;
        }

        public override void Update()
        {
            base.Update();

            durationTimer -= Time.deltaTime;
            player.SetVelocity(player.dir * player.dashSpeed, rg.velocity.y);
            
            // detect wall or time out to stop dashing
            if (durationTimer < 0 || player.DetectWall())
            {
                if (machine.isRunning)
                {
                    machine.ChangeState(machine.RunState);
                }
                else
                {
                    machine.ChangeState(machine.IdleState);
                }
            }
        }

        public override void Exit()
        {
            base.Exit();
            
            machine.isDashing = false;
        }

        protected override void Flip()
        {
            // do not flip when dashing
        }
    }
}