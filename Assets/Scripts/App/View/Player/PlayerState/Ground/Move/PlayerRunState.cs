using App.Base;
using UnityEngine;

namespace App.View
{
    public class PlayerRunState: PlayerGroundState
    {
        public PlayerRunState(BaseRole p, PlayerStateMachine m, string argsName) : base(p, m, argsName)
        {
        }

        public override void Enter()
        {
            base.Enter();

            machine.isRunning = true;
        }

        public override void Update()
        {
            base.Update();

            if (xAxis == 0)
            {
                machine.ChangeState(machine.IdleState);
            }

            if (player.DetectWall())
            {
                // collide with wall and stop
                player.SetVelocity(0 , player.rg.velocity.y);
            }
            else
            {
                player.SetVelocity(xAxis * player.runSpeed , player.rg.velocity.y);
            }
            
        }
    }
}