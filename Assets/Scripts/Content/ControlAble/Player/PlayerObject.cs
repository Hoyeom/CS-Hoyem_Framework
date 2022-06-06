using System;
using System.Collections.Generic;
using Content.Status;
using UnityEngine;
using UnityEngine.InputSystem;
using Utils;

namespace Content
{
    public class PlayerObject : ControlObjectBase
    {
        [SerializeField] private StatusBase _statusBase;
        [SerializeField] private Vector3 velocity = Vector3.zero;

        [SerializeField] private Transform firePoint;
        [SerializeField] private LayerMask aimLayer;

        private Dictionary<Type, PlayerStateBase> _states = new Dictionary<Type, PlayerStateBase>();
        private PlayerStateBase curState;

        private Vector3 moveInput;

        private Rigidbody rigid;

        private Camera cam;
        private Transform camRig;
        private CameraController camController;
        private Quaternion camY;

        private float aimMaxDistance = 40;

        private bool isGround;

        protected override void Initialize()
        {
            rigid = GetComponent<Rigidbody>();

            cam = Camera.main;
            camController = Managers.Game.Camera;
            camRig = camController.GetRig();

            ChangeState<PlayerIdleState>();

            Managers.Game.Camera.SetFollowTarget(transform);
            Managers.Game.Camera.SetOffset(Vector3.up * 4);
            base.Initialize();
        }

        public override void MouseDelta(Vector2 input)
        {
            camController.RotateCamera(input);
        }

        private void Update()
        {
            camY = Quaternion.Euler(new Vector3(0, camRig.eulerAngles.y, 0));
            GroundCheck();
            curState.OnUpdate();
        }

        public void Move()
        {
            rigid.MovePosition(rigid.position + camY * velocity * Time.deltaTime);

            if (Keyboard.current.spaceKey.wasPressedThisFrame && isGround)
                rigid.AddForce(Vector3.up * 5, ForceMode.Impulse);
        }

        public void Rotate()
        {
            if (!(moveInput.magnitude > 0)) return;
            Quaternion targetRotation = camY * Quaternion.LookRotation(moveInput);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 20 * Time.deltaTime);
        }

        public void LockRotate()
        {
            transform.rotation = camY;
        }
        
        public override void MoveInput(Vector2 input)
        {
            Vector3 dir = input;
            (dir.y, dir.z) = (dir.z, dir.y);

            moveInput = dir;
            velocity = (moveInput * _statusBase.speed);
        }

        public override void FireInput(Define.PressEvent phase)
        {
            ChangeState<PlayerCombatState>();
            transform.rotation = camY;
            GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            obj.transform.position = firePoint.position;
            obj.AddComponent<Rigidbody>().AddForce(GetScreenCenterWorldPoint() - transform.position, ForceMode.Impulse);
        }

        public void ChangeState<T>() where T : PlayerStateBase, new()
        {
            Type type = typeof(T);
            if (!_states.ContainsKey(type))
            {
                _states.Add(type, new T());
                curState = _states[type];
                curState.Player = this;
                curState.EnterState();
            }
            else
            {
                curState.ExitState();
                curState = _states[type];
                curState.EnterState();
            }
        }

        private void GroundCheck()
        {
            Ray ray = new Ray(transform.position + Vector3.up,Vector3.down);

            isGround = Physics.SphereCast(ray,
                .5f, out RaycastHit hit, 1);
        }


        private Vector3 GetScreenCenterWorldPoint()
        {
            Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));

            bool isHit = Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, aimLayer.value);

            Vector3 point = isHit
                ? hit.point
                : (cam.transform.position + cam.transform.forward * aimMaxDistance);

            return point;
        }
    }
}