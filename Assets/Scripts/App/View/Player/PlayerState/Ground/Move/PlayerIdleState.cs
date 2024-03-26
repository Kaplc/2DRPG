using App.Base;

namespace App.View
{
    public class PlayerIdleState : PlayerGroundState
    {
        public PlayerIdleState(BaseRole p, PlayerStateMachine m, string argsName) : base(p, m, argsName)
        {
            
        }

        public override void Enter()
        {
            base.Enter();
            
            player.SetVelocity(0,0);
            machine.isRunning = false;
        }

        public override void Update()
        {
            base.Update();
            
            // change run state
            if (xAxis != 0)
            {
                machine.ChangeState(machine.RunState);
            }
        }
    }
}