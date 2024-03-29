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
            rg.velocity = new Vector2(0, rg.velocity.y);
        }

        public override void Update()
        {
            base.Update();

            durationTimer -= Time.deltaTime;
            rg.velocity = new Vector2(player.dir * player.dashSpeed, rg.velocity.y);
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

            rg.velocity = Vector2.zero;
        }

        protected override void Flip()
        {
            // do not flip when dashing
        }
    }
}