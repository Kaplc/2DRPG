using App.Base;

namespace App.View
{
    public class PlayerIdleState : BasePlayerState
    {
        public PlayerIdleState(Player p, PlayerStateMachine m, string argsName) : base(p, m, argsName)
        {
            
        }

        public override void Enter()
        {
            base.Enter();
            
            player.SetVelocity(0,0);
        }

        public override void Update()
        {
            base.Update();
            
            // change run state
            if (xAxis != 0)
            {
                machine.ChangeState(player.runState);
            }
        }
    }
}