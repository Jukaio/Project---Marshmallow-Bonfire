using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraForTwo : MonoBehaviour
{
    private Camera mainCamera;

    public List<Transform> targets;
    public Vector3 offset;
    private Vector3 velocity;
    public float time = 0.5f;

    public float minZoom = 100f;
    public float maxZoom = 40f;

    private void LateUpdate()
    {
        mainCamera = GetComponent<Camera>();
        MoveCamera();
        ZoomCamera();

        foreach (Transform target in targets)
        {
            if (target.position.x >= transform.position.x + mainCamera.aspect * mainCamera.orthographicSize)
            {
                Debug.Log("HEY LISTEN");
            }
            else if (target.position.x <= transform.position.x - mainCamera.aspect * mainCamera.orthographicSize)
            {
                Debug.Log("HEY LISTEN");
            }
        }


    }

    void ZoomCamera()
    {
        float zoom = Mathf.Lerp(maxZoom, minZoom, GetDistance() / 50);
        //mainCamera.fieldOfView = zoom;

        mainCamera.orthographicSize = zoom;
    }

    void MoveCamera()
    {
        Vector3 centerPoint = GetCenterPoint();
        Vector3 newPos = centerPoint + offset;
        transform.position = Vector3.SmoothDamp(transform.position, newPos, ref velocity, time);
    }

    float GetDistance()
    {
        var bounds = new Bounds(targets[0].position, Vector3.zero);
        for (int i = 0; i < targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].position);
        }
        return bounds.size.x;
    }

    Vector3 GetCenterPoint()
    {
        var bounds = new Bounds(targets[0].position, Vector3.zero);
        for (int i = 0; i < targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].position);
        }
        return bounds.center;
    }
}
