using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera m_camera;
    public Transform target;

    [Header("Properties")]
    public float smoothSpeed;
    public Vector3 positionOffset;
    public bool lookAt;
    public Vector3 lookOffset;

    private Vector3 velocity = Vector3.zero;
    private void Start()
    {
        m_camera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }
    private void LateUpdate()
    {
        if (target != null)
        {
            Vector3 desitedPos = target.position + positionOffset;
            Vector3 smoothedPos = Vector3.SmoothDamp(m_camera.transform.position, desitedPos, ref velocity, smoothSpeed);
            m_camera.transform.position = smoothedPos;

            if (lookAt)
                m_camera.transform.LookAt(target.position + lookOffset);
        }
    }

    public void SmoothAdjust(float speed)
    {
        smoothSpeed = speed;
    }

    public void Xoffest(float x)
    {
        positionOffset.z = x *-1;
    }
    public void yoffest(float y)
    {
        positionOffset.y = y;
    }

    public void Lookoffest(float x)
    {
        lookOffset.z = x;
    }
}
