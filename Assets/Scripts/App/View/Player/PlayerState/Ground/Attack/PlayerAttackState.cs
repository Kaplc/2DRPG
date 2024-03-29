using App.Base;
using UnityEngine;

namespace App.View.Ground.Attack
{
    public class PlayerAttackState : PlayerGroundState
    {
        #region count attack

        private int attackCount;
        private float AttackWindowTime => player.attackWindowTime;
        private float lastAttackTime;

        #endregion
        
        public bool dashAttack;

        public bool attacking;
        
        public PlayerAttackState(BaseRole role, BaseStateMachine stateMachine, string argsName) : base(role, stateMachine, argsName)
        {
            
        }

        public override void Enter()
        {
            base.Enter();

            if (dashAttack)
            {
                machine.animator.SetBool("DashAttack", true);
            }
            else
            {
                // reset attack count
                if(attackCount > 1 || Time.time >= lastAttackTime + AttackWindowTime){
                    attackCount = 0;
                }
            
                machine.animator.SetInteger("AttackCount", attackCount);
            }
            
            attacking = true;

            player.SetVelocity(0, 0);
        }

        public override void Update()
        {
            base.Update();

            if (player.animationFinish)
            {
                machine.ChangeState(machine.IdleState);
            }
        }

        public override void Exit()
        {
            base.Exit();

            attackCount++;
            lastAttackTime = Time.time;
            attacking = false;

            if (dashAttack)
            {
                machine.animator.SetBool("DashAttack", false);
                dashAttack = false;
            }
        }

        protected override void Flip()
        {
            if (attacking) return;

            base.Flip();
        }
    }
}