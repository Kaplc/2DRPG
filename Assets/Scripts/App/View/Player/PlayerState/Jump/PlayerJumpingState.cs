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
        rg.velocity = new Vector2(rg.velocity.x, player.jumpForce);
    }
    
    public override void Exit()
    {
        base.Exit();
    }
    
    public override void Update()
    {
        base.Update();
        
        // near the top
        if (Mathf.Abs(player.rg.velocity.y) < 0.1f)
            machine.ChangeState(machine.ToppingState);
    }
}
