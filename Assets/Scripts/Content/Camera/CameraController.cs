using System;
using DG.Tweening;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Serializable]
    public class Target
    {
        public Transform look;
        public Transform follow;
        
        public Vector3 offset = Vector3.zero;

        public Vector3 GetLookPos() => look.position + offset;
        public Vector3 GetFollowPos() => follow.position + offset;
    }
    
    private Transform rig;
    private float distance;

    [SerializeField] private Target _target = new Target();

    private Action CameraAction;

    public Quaternion RigRotation
    {
        get => rig.rotation;
        set => rig.rotation = value;
    }

    private void Awake()
    {
        rig = transform.parent;
    }

    private void LateUpdate()
    {
        CameraAction?.Invoke();
    }

    public Transform GetRig() => rig;
    
    public void SetTarget(Transform target)
    {
        _target.follow = target;
        _target.look = target;

        CameraAction -= Look;
        CameraAction += Look;
        CameraAction -= Follow;
        CameraAction += Follow;
    }

    public void SetFollowTarget(Transform target)
    {
        _target.follow = target;

        CameraAction -= Look;
        CameraAction -= Follow;
        CameraAction += Follow;
    }

    public void SetLookTarget(Transform target)
    {
        _target.look = target;

        CameraAction -= Follow;
        CameraAction -= Look;
        CameraAction += Look;
    }

    public void SetOffset(Vector3 value)
    {
        _target.offset = value;
    }
    
    private void Follow()
    {
        rig.position = _target.GetFollowPos();
    }
    
    
    private void Look()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation,
            Quaternion.LookRotation(_target.GetLookPos() - transform.position), Time.deltaTime);
    }
}
