using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera camera;
    public Transform target;

    [Header("Properties")]
    public float smoothSpeed;
    public Vector3 positionOffset;
    public bool lookAt;
    public Vector3 lookOffset;

    private Vector3 velocity = Vector3.zero;
    private void LateUpdate()
    {
        if (target != null)
        {
            Vector3 desitedPos = target.position + positionOffset;
            Vector3 smoothedPos = Vector3.SmoothDamp(camera.transform.position, desitedPos, ref velocity, smoothSpeed);
            camera.transform.position = smoothedPos;

            if (lookAt)
                camera.transform.LookAt(target.position + lookOffset);
        }
    }

}
