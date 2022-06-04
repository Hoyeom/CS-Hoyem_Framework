using System;
using UnityEngine;

namespace Content
{
    public abstract class ControlObjectBase : MonoBehaviour
    {
        private void Start()
        {
            Initialize();
        }

        protected virtual void Initialize()
        {
            Managers.Game.Controller.SubscribeControl(this); // Test
        }
        
        public abstract void MouseDelta(Vector2 input);

        public abstract void MoveInput(Vector2 input);
    }
}