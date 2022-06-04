using System;
using Content.Status;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Content
{
    public class UnitObject : ControlObjectBase
    {
        [SerializeField] private StatusBase _statusBase;
        [SerializeField] private Vector3 velocity = Vector3.zero;
        
        private Rigidbody rigid;

        private Transform camRig;
        
        protected override void Start()
        {
            rigid = GetComponent<Rigidbody>();
            Managers.Game.Camera.SetFollowTarget(transform);
            camRig = Managers.Game.Camera.GetRig();
            base.Start();
        }

        public override void MouseDelta(Vector2 input)
        {
            Vector3 eulerAngle = camRig.eulerAngles;
            camRig.eulerAngles = new Vector3(Mathf.Clamp(-input.y + eulerAngle.x, 0, 87), -input.x + eulerAngle.y);
        }

        private void Update()
        {
            Quaternion camY = Quaternion.Euler(new Vector3(0, camRig.eulerAngles.y, 0));
            
            rigid.MovePosition(rigid.position + camY * velocity * Time.deltaTime);
        }

        public override void MoveInput(Vector2 input)
        {
            Vector3 dir = input;
            (dir.y, dir.z) = (dir.z, dir.y);
            velocity = dir * _statusBase.speed;
        }
    }
}