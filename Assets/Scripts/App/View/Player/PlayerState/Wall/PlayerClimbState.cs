using App.Base;

namespace App.View.Wall
{
    public class PlayerClimbState: BasePlayerState
    {
        public PlayerClimbState(BaseRole role, BaseStateMachine stateMachine, string argsName) : base(role, stateMachine, argsName)
        {
        }

        public override void Enter()
        {
            base.Enter();

            machine.isJumpFromWall = true;
            player.SetVelocity(rg.velocity.x, player.jumpForce);
        }

        public override void Update()
        {
            base.Update();
            
            // allow to control x speed
            if (player.DetectWall())
            {
                // if player is on the wall, can not move x
                player.SetVelocity(0, rg.velocity.y);
            }
            else
            {
                player.SetVelocity(xAxis * player.runSpeed, rg.velocity.y); 
            }
            

            if (player.DetectGround())
            {
                machine.ChangeState(machine.IdleState);
            }
        }
    }
}