using App.Base;
using UnityEngine;

namespace App.View.Ground.Attack
{
    public class PlayerAttackState : PlayerGroundState
    {

        private int attackCount;
        private float attackWindowTime => player.attackWindowTime;
        private float lastAttackTime;

        public bool attacking;

        public PlayerAttackState(BaseRole role, BaseStateMachine stateMachine, string argsName) : base(role, stateMachine, argsName)
        {
            
        }

        public override void Enter()
        {
            base.Enter();

            // reset attack count
            if(attackCount > 1 || Time.time >= lastAttackTime + attackWindowTime){
                attackCount = 0;
            }
            
            machine.animator.SetInteger("AttackCount", attackCount);
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
        }

        protected override void Flip()
        {
            if (attacking) return;

            base.Flip();
        }
    }
}