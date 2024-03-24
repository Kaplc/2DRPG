namespace App.Base
{
    public class BaseStateMachine
    {
        public BaseState CurrentState { get; protected set; }
        
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