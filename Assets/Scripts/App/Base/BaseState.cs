using UnityEngine;

namespace App.Base
{
    public interface IState
    {
        public void Enter();
        public void Exit();
        public void Update();
    }
    
    public abstract class BaseState: IState
    {
        private string argsName;
        
        protected BaseRole role;
        protected BaseStateMachine machine;
        protected Rigidbody2D rg;
        
        
        public BaseState(BaseRole role, BaseStateMachine stateMachine, string argsName)
        {
            this.role = role;
            this.machine = stateMachine;
            this.argsName = argsName;
            rg = role.rg;
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