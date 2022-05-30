using UnityEngine;

namespace Content.Units
{
    public class StateIdle : StateBase
    {
        public override void StateEnter(Unit unit)
        {
            base.StateEnter(unit);
            curUnit.ChangeState<StateRun>();
        }


        public override void StateUpdate()
        {
            
        }

        public override void StateExit()
        {
            
        }
    }
}