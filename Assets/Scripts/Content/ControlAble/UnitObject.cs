using System;
using Content.Status;
using UnityEngine;

namespace Content
{
    public class UnitObject : ControlObjectBase
    {
        [SerializeField] private StatusBase _statusBase;
        [SerializeField] private Vector3 velocity = Vector3.zero;
        
        private Rigidbody rigid;
        
        protected override void Start()
        {
            rigid = GetComponent<Rigidbody>();
            base.Start();
        }

        public override void MouseDelta(Vector2 input)
        {
            
        }

        private void Update()
        {
            rigid.MovePosition(rigid.position + velocity * Time.deltaTime);
        }

        public override void MoveInput(Vector2 input)
        {
            Vector3 dir = input;
            (dir.y, dir.z) = (dir.z, dir.y);
            velocity = dir * _statusBase.speed;
        }
    }
}