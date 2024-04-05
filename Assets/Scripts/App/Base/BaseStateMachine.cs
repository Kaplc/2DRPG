using System.Collections;
using UnityEngine;

namespace App.Base
{
    public abstract class BaseStateMachine
    {
        public BaseRole role;
        public readonly Animator animator;
        public BaseState CurrentState { get; private set; }

        protected BaseStateMachine(BaseRole role, Animator animator)
        {
            this.role = role;
            this.animator = animator;
        }

        public virtual void Initialize(BaseState startingState)
        {
            CurrentState = startingState;
            CurrentState.Enter();
        }

        public virtual void ChangeState(BaseState newState)
        {
            CurrentState.Exit();
            CurrentState = newState;
            CurrentState.Enter();
        }
    }
}