namespace Content
{
    public class PlayerIdleState : PlayerStateBase
    {
        public override void EnterState()
        {
            
        }

        public override void OnUpdate()
        {
            Player.Move();
            Player.Rotate();
        }

        public override void ExitState()
        {
            
        }
    }
}