using App.Base;
using UnityEngine;

namespace App.View
{
    public class BasePlayerState: BaseState
    {
        protected float xAxis;
        protected float yAxis;

        protected Player player => (Player) role;
        protected new PlayerStateMachine machine => base.machine as PlayerStateMachine;

        public BasePlayerState(BaseRole role, BaseStateMachine stateMachine, string argsName) : base(role, stateMachine, argsName)
        {
        }

        public override void Update()
        {
            base.Update();
            
            xAxis = Input.GetAxisRaw("Horizontal");
            yAxis = Input.GetAxisRaw("Vertical");
            machine.animator.SetFloat("yVelocity", rg.velocity.y);
            
            
            Flip();
        }

        private void Flip()
        {
            if (xAxis > 0)
            {
                player.transform.rotation = Quaternion.Euler(0, 0, 0);
                player.dir = 1;
            }
            else if (xAxis < 0)
            {
                player.transform.rotation = Quaternion.Euler(0, 180, 0);
                player.dir = -1;
            }
        }
    }
}