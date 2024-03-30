using App.Base;
using App.View.Ground.Attack;
using App.View.Wall;
using UnityEngine;

namespace App.View
{
    public class PlayerStateMachine: BaseStateMachine
    {
        public bool isRunning;
        // ground state
        public PlayerGroundState GroundState { get; private set; }
        public PlayerIdleState IdleState { get; private set; }
        public PlayerRunState RunState { get; private set; }
        public PlayerDashState DashState { get; private set; }
        public PlayerDownDashState PlayerDownDashState { get; private set; }
        // attack state
        public PlayerAttackState AttackState { get; private set; }
        // jump state
        public PlayerJumpingState JumpingState { get; private set; }
        public PlayerToppingState ToppingState { get; private set; }
        public PlayerFallingState FallingState { get; private set; }
        // wall
        public PlayerHangOnWallState HangOnWallState { get; private set; }
        
        public PlayerStateMachine(BaseRole role ,Animator animator) : base(role ,animator)
        {
            // ground state
            GroundState = new PlayerGroundState(role, this, "Ground");
            IdleState = new PlayerIdleState(role, this, "Idle");
            RunState = new PlayerRunState(role, this, "Run");
            DashState = new PlayerDashState(role, this, "Dash");
            PlayerDownDashState = new PlayerDownDashState(role, this, "DownDash");
            // attack state
            AttackState = new PlayerAttackState(role, this, "Attack");
            // jump state
            JumpingState = new PlayerJumpingState(role, this, "Jump");
            ToppingState = new PlayerToppingState(role, this, "Jump");
            FallingState = new PlayerFallingState(role, this, "Jump");
            // wall state
            HangOnWallState = new PlayerHangOnWallState(role, this, "HangOnWall");
        }
    }
}
