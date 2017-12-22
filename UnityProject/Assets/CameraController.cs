using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    [SerializeField]
    private Transform m_target = null;
    [SerializeField]
    private float m_speed = 0.0f;

    public Transform Target
    {
        get { return m_target; }
    }

    private Transform m_cameraTransform = null;
    private Transform m_pivot = null;

    private void Awake()
    {
        Camera camera = GetComponentInChildren<Camera>();
        Debug.AssertFormat(camera != null, "カメラが無ぇよ!");
        if (camera == null)
        {
            return;
        }

        m_cameraTransform = camera.transform;
        m_pivot = m_cameraTransform.parent;
    }

    private void LateUpdate()
    {
        UpdateCamera();
    }

    private void UpdateCamera()
    {
        if (Target == null)
        {
            return;
        }

        Vector3 targetPos = Target.position;

        float deltaSpeed = m_speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetPos, deltaSpeed);
    }

    [ContextMenu("ApplyTarget")]
    private void ApplyForceTarget()
    {
        if (Target == null)
        {
            return;
        }

        transform.position = Target.position;

        SetCameraTransform();
        if (m_cameraTransform == null)
        {
            return;
        }

        m_cameraTransform.transform.LookAt(Target);
    }

    private void SetCameraTransform()
    {
        Camera camera = GetComponentInChildren<Camera>();
        Debug.AssertFormat(camera != null, "カメラが無ぇよ!");
        if (camera == null)
        {
            return;
        }

        m_cameraTransform = camera.transform;
        m_pivot = m_cameraTransform.parent;
    }

    public void Turn(float i_angle)
    {
        transform.rotation *= Quaternion.AngleAxis(i_angle, Vector3.up);
    }

}
