using App.Base;
using UnityEngine;

namespace App.View
{
    public class PlayerGroundState : BasePlayerState
    {
        public PlayerGroundState(BaseRole role, BaseStateMachine stateMachine, string argsName) : base(role, stateMachine, argsName)
        {
        }

        public override void Enter()
        {
            base.Enter();
            // reset jump from wall
            machine.isJumpFromWall = false;
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void Update()
        {
            base.Update();

            // jump
            if (Input.GetKeyDown(KeyCode.Space) && (player.DetectGround() || player.DetectLadder()))
            {
                machine.ChangeState(machine.JumpingState);
            }
            
            // fall down
            if (rg.velocity.y < -1f)
            {
                machine.ChangeState(machine.ToppingState);
            }
        }
    }
}