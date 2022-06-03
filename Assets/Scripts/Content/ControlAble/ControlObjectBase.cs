using System;
using UnityEngine;

namespace Content
{
    public class ControlObjectBase : MonoBehaviour
    {
        private void Start()
        {
            Managers.Game.Controller.SubscribeControl(this);
        }

        public void MouseDelta(Vector2 input)
        {
            Debug.Log($"Mouse {input}");
        }

        public void MoveInput(Vector2 input)
        {
            Debug.Log($"Move {input}");
        }
    }
}