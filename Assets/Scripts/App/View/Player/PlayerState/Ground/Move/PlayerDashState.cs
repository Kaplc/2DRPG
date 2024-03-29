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
            
            player.isDashing = true;
        }

        public override void Update()
        {
            base.Update();

            durationTimer -= Time.deltaTime;
            rg.velocity = new Vector2(player.dir * player.dashSpeed, rg.velocity.y * player.dashingFallingSpeed);
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
            
            player.isDashing = false;
        }
    }
}