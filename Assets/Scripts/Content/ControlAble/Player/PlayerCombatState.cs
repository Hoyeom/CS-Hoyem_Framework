using UnityEngine;

namespace Content
{
    public class PlayerCombatState : PlayerStateBase
    {
        private float combatDelay = 3;
        private float combatTimer;
        
        public override void EnterState()
        {
            combatTimer = Time.time;
        }

        public override void OnUpdate()
        {
            Player.Move();
            Player.LockRotate();

            if (combatTimer + combatDelay < Time.time)
                Player.ChangeState<PlayerIdleState>();
        }

        public override void ExitState()
        {
            
        }
    }
}