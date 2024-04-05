using App.Base;

namespace App.View
{
    public class PlayerDeadState: BasePlayerState
    {
        public PlayerDeadState(BaseRole role, BaseStateMachine stateMachine, string argsName) : base(role, stateMachine, argsName)
        {
        }
        
        public override void Enter()
        {
            base.Enter();
            player.SetVelocity(0,0);
            
            machine.animator.SetInteger("DeadId", 2);
        }
        
        public override void Update()
        {
            
        }
    }
}