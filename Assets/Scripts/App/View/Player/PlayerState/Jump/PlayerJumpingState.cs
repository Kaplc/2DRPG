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
        Debug.Log(rg.velocity.x);
    }
    
    public override void Exit()
    {
        base.Exit();
    }
    
    public override void Update()
    {
        base.Update();
        
        // can not jump x speed over 1.25
        rg.velocity = new Vector2(Mathf.Clamp(rg.velocity.x, -1.25f, 1.25f), rg.velocity.y);

        // near the top
        if (Mathf.Abs(player.rg.velocity.y) < 0.1f)
            machine.ChangeState(machine.ToppingState);
    }
}
