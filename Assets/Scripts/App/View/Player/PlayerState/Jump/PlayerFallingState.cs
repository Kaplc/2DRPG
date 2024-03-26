using App.Base;

namespace App.View
{
    public class PlayerFallingState: BasePlayerState
    {
        public PlayerFallingState(BaseRole role, BaseStateMachine stateMachine, string argsName) : base(role, stateMachine, argsName)
        {
        }
        
        public override void Enter()
        {
            base.Enter();
        }
        
        public override void Exit()
        {
            base.Exit();
        }
        
        public override void Update()
        {
            base.Update();

            if (player.DetectGround())
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
    }
}