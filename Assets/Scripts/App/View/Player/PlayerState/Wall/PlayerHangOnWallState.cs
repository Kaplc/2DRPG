using App.Base;

namespace App.View.Wall
{
    public class PlayerHangOnWallState: BasePlayerState
    {
        public PlayerHangOnWallState(BaseRole role, BaseStateMachine stateMachine, string argsName) : base(role, stateMachine, argsName)
        {
        }

        public override void Enter()
        {
            base.Enter();

            rg.gravityScale = 0;
        }

        public override void Update()
        {
            base.Update();
            
            player.SetVelocity(0,0);
        }

        public override void Exit()
        {
            base.Exit();
            
            rg.gravityScale = 1;
        }
    }
}