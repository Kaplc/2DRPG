using App.Base;
using UnityEngine;

namespace App.View
{
    public class PlayerGroundState: BasePlayerState
    {
        public PlayerGroundState(BaseRole role, BaseStateMachine stateMachine, string argsName) : base(role, stateMachine, argsName)
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
            
            // jump
            if (Input.GetKeyDown(KeyCode.Space))
            {
                machine.ChangeState(machine.JumpingState);
            }
        }
    }
}