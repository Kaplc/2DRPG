using App.Base;
using UnityEngine;

namespace App.View
{
    public class PlayerDownDashState : PlayerGroundState
    {
        private float durationTimer;

        public PlayerDownDashState(BaseRole role, BaseStateMachine stateMachine, string argsName) : base(role, stateMachine, argsName)
        {
        }

        public override void Enter()
        {
            base.Enter();

            durationTimer = player.downDashDuration;
            // slow
            player.SetVelocity(0, rg.velocity.y);
        }

        public override void Update()
        {
            base.Update();

            durationTimer -= Time.deltaTime;
            player.SetVelocity(player.dir * player.dashSpeed, rg.velocity.y);
            if (durationTimer < 0)
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
            
            player.SetVelocity(0,0);
        }

        protected override void Flip()
        {
            // do not flip when dashing
        }
    }
}