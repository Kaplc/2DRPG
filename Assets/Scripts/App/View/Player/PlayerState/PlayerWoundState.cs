using App.Base;
using UnityEngine;

namespace App.View
{
    public class PlayerWoundState : BasePlayerState
    {

        public PlayerWoundState(BaseRole role, BaseStateMachine stateMachine, string argsName) : base(role, stateMachine, argsName)
        {
        }

        public override void Enter()
        {
            base.Enter();
            
            machine.isWounded = true;
            player.SetVelocity(0,0);
            // add force to player
            player.AddForce(-player.dir * player.woundForce, 3 );
        }

        public override void Update()
        {
            base.Update();
            
            if (player.animationFinish)
            {
                
                machine.ChangeState(machine.IdleState);
            }
        }
        
        public override void Exit()
        {
            base.Exit();
            machine.isWounded = false;
        }
    }
}