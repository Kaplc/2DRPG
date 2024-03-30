using System.Collections;
using System.Collections.Generic;
using App.Base;
using App.View;
using UnityEngine;

public class PlayerJumpingState : BasePlayerState
{
    public PlayerJumpingState(BaseRole role, BaseStateMachine stateMachine, string argsName) : base(role, stateMachine, argsName)
    {
        
    }
    
    public override void Enter()
    {
        base.Enter();
        
        // up force to jump
        player.SetVelocity(rg.velocity.x, player.jumpForce);
    }
    
    public override void Exit()
    {
        base.Exit();
    }
    
    public override void Update()
    {
        base.Update();
        
        // can not jump x speed over 1.25
        player.SetVelocity(Mathf.Clamp(rg.velocity.x, -1.25f, 1.25f), rg.velocity.y);

        // near the top
        if (Mathf.Abs(player.rg.velocity.y) < 0.1f)
            machine.ChangeState(machine.ToppingState);
    }
}
