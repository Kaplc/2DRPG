using App.Base;

namespace App.View
{
    public class PlayerToppingState : BasePlayerState
    {
        public PlayerToppingState(BaseRole role, BaseStateMachine stateMachine, string argsName) : base(role, stateMachine, argsName)
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

            if (player.rg.velocity.y > -0.1f)
            {
                machine.ChangeState(machine.FallingState);
            }
        }
    }
}