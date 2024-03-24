using App.Base;

namespace App.View
{
    public class PlayerRunState: BasePlayerState
    {
        public PlayerRunState(Player p, PlayerStateMachine m, string argsName) : base(p, m, argsName)
        {
        }

        public override void Update()
        {
            base.Update();

            if (xAxis == 0)
            {
                machine.ChangeState(player.idleState);
            }
            
            player.SetVelocity(xAxis * player.runSpeed , player.roleRg.velocity.y);
        }
    }
}