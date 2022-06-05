using System;
using DG.Tweening;
using UnityEngine;
using Utils;

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
    
    [SerializeField] private Define.Layer blockLayer;
    private int BlockLayer { get; set; }
    [SerializeField] private float distance = 10;
    [SerializeField] private float lerpTime = 2;
    [SerializeField] private Target _target = new Target();

    private Action CameraAction;

    public Quaternion RigRotation
    {
        get => rig.rotation;
        set => rig.rotation = value;
    }

    private void Awake()
    {
        BlockLayer = (int) blockLayer;
        rig = transform.parent;
    }

    private void LateUpdate()
    {
        CameraAction?.Invoke();
        ClampDistance();
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

    public void RotateCamera(Vector3 input, float min = -80, float max = 80)
    {
        Vector3 camRigEulerAngle = rig.eulerAngles;

        float angleX = -input.y + camRigEulerAngle.x;
        angleX = Mathf.Clamp((angleX > 180) ? angleX - 360 : angleX, min, max);

        float angleY = -input.x + camRigEulerAngle.y;

        rig.eulerAngles = new Vector3(angleX, angleY);
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

    private void ClampDistance()
    {
        Ray ray = new Ray(rig.position, -transform.forward);
        
        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity,BlockLayer))
            transform.localPosition = Mathf.Min(distance, hit.distance) * Vector3.back;
        else
            transform.localPosition = Vector3.Lerp(transform.localPosition, distance * Vector3.back, lerpTime * Time.deltaTime);
    }
}
