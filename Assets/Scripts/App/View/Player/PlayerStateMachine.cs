using App.Base;
using App.View.Climb;
using App.View.Ground.Attack;
using App.View.Wall;
using UnityEngine;

namespace App.View
{
    public class PlayerStateMachine: BaseStateMachine
    {
        public Player Player => (Player)role;
        
        #region state info
        public bool isRunning;
        public bool isJumpFromWall;
        public bool isDashing;
        public bool isClimbing;
        public bool isWounded;
        #endregion


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
        public PlayerClimbWallState ClimbWallState { get; private set; }
        public PlayerSlidingWallState SlidingWallState { get; private set; }
        // climb
        public PlayerClimbLadderState ClimbLadderState { get; private set; }
        // wound
        public PlayerWoundState WoundState { get; private set; }
        // dead
        public PlayerDeadState DeadState { get; private set; }
        
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
            ClimbWallState = new PlayerClimbWallState(role, this, "Jump");
            SlidingWallState = new PlayerSlidingWallState(role, this, "SlidingWall");
            // ladder state
            ClimbLadderState = new PlayerClimbLadderState(role, this, "ClimbLadder");
            // wound state
            WoundState = new PlayerWoundState(role, this, "Wound");
            // dead state
            DeadState = new PlayerDeadState(role, this, "Dead");
        }

        public override void ChangeState(BaseState newState)
        {
            if (Player.isDead && newState != IdleState)
            {
                return; 
            }
            base.ChangeState(newState);
        }
    }
}
