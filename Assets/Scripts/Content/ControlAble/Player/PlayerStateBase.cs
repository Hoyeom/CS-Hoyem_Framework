namespace Content
{
    public abstract class PlayerStateBase
    {
        public PlayerObject Player;
        public abstract void EnterState();
        public abstract void OnUpdate();
        public abstract void ExitState();
    }
}