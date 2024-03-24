using UnityEngine;

namespace App.Base
{
    public abstract class BaseState
    {
        protected string argsName;
        
        public BaseRole role;
        public BaseStateMachine machine;
        
        
        public BaseState(BaseRole role, BaseStateMachine stateMachine, string argsName)
        {
            this.role = role;
            this.machine = stateMachine;
            this.argsName = argsName;
        }

        public virtual void Update()
        {
            
        }
        
        public virtual void Enter()
        {
            role.animator.SetBool(argsName, true);
        }
        
        public virtual void Exit()
        {
            role.animator.SetBool(argsName, false);
        }
    }
}