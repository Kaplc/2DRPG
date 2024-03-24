using System;
using UnityEngine;

namespace App.View
{
    public class Player : BaseRole
    {

        #region move info

        public float runSpeed;

        #endregion
        
        #region state

        private PlayerStateMachine StateMachine;

        public PlayerIdleState idleState { get; private set; }
        public PlayerRunState runState { get; private set; }

        #endregion

        public override void Awake()
        {
            base.Awake();

            StateMachine = new PlayerStateMachine();
            // int state
            idleState = new PlayerIdleState(this, StateMachine, "Idle");
            runState = new PlayerRunState(this, StateMachine, "Run");
        }


        public override void Start()
        {
            base.Start();

            StateMachine.Initialize(idleState);
        }


        public override void Update()
        {
            base.Update();

            StateMachine.CurrentState.Update();
        }

        #region velocity

        public void SetVelocity(float x, float y)
        {
            roleRg.velocity = new Vector2(x, y);
        }
        #endregion
    }
}