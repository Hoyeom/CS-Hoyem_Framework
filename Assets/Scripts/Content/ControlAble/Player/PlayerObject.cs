using System;
using Content.Status;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Content
{
    public class PlayerObject : ControlObjectBase
    {
        [SerializeField] private StatusBase _statusBase;
        [SerializeField] private Vector3 velocity = Vector3.zero;
        
        private Rigidbody rigid;

        private CameraController cam;
        private Transform camRig;
        
        
        
        protected override void Initialize()
        {
            rigid = GetComponent<Rigidbody>();
            Managers.Game.Camera.SetFollowTarget(transform);
            cam = Managers.Game.Camera;
            camRig = cam.GetRig();
            Managers.Game.Camera.SetOffset(Vector3.up);
            base.Initialize();
        }

        public override void MouseDelta(Vector2 input)
        {
            cam.RotateCamera(input);
        }

        private void Update()
        {
            Move();
            if(Keyboard.current.spaceKey.wasPressedThisFrame)
                rigid.AddForce(Vector3.up * 5,ForceMode.Impulse);
        }

        private void Move()
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