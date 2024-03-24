using App.Base;
using UnityEngine;

namespace App.View
{
    public class BasePlayerState: BaseState
    {
        protected float xAxis;
        protected float yAxis;
        
        public Player player => (Player) role;

        public BasePlayerState(BaseRole role, BaseStateMachine stateMachine, string argsName) : base(role, stateMachine, argsName)
        {
        }

        public override void Update()
        {
            base.Update();
            
            xAxis = Input.GetAxisRaw("Horizontal");
            yAxis = Input.GetAxisRaw("Vertical");

            if (xAxis > 0)
            {
                player.transform.rotation = Quaternion.Euler(0,0,0);
            }
            else if (xAxis < 0)
            {
                player.transform.rotation = Quaternion.Euler(0,180,0);
            }
        }
    }
}