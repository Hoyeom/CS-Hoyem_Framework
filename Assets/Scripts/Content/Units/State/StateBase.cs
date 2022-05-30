namespace Content.Units
{
    public abstract class StateBase
    {
        protected Unit curUnit = null;
        public virtual void StateEnter(Unit unit)
        {
            curUnit = unit;
        }

        public abstract void StateUpdate();

        public abstract void StateExit();
    }
}