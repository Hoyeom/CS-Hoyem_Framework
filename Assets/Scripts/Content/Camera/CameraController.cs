using System;
using DG.Tweening;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform rig;
    private float distance;
    private Transform lookTarget;
    private Transform followTarget;

    private Action CameraAction;
    
    private void Awake()
    {
        rig = transform.parent;
    }

    private void LateUpdate()
    {
        CameraAction?.Invoke();
    }
    
    public void SetTarget(Transform target)
    {
        lookTarget = target;
        followTarget = target;

        CameraAction -= Look;
        CameraAction += Look;
        CameraAction -= Follow;
        CameraAction += Follow;
    }

    private void Follow()
    {
        rig.position = followTarget.position;
    }
    
    private void Look()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation,
            Quaternion.LookRotation(lookTarget.position - transform.position), Time.deltaTime);
    }
}
