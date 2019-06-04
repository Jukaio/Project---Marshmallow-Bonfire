using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;

public class CameraForTwo : MonoBehaviour
{
    private Camera mainCamera;

    public List<Transform> targets;
    public Vector3 offset;
    private Vector3 velocity;
    public float time = 0.5f;

    SceneScripts sceneCode;

    public float minZoom = 100f;
    public float maxZoom = 40f;

    private void Start()
    {
        sceneCode = GetComponent<SceneScripts>();
    }

    private void LateUpdate()
    {
        mainCamera = GetComponent<Camera>();
        MoveCamera();
        ZoomCamera();

        if (targets[0].GetComponent<Command>().resetActive && targets[1].GetComponent<Command>().resetActive)
            sceneCode.ReloadScene();

        if (targets[0].GetComponent<Command>().startActive && targets[1].GetComponent<Command>().startActive)
            sceneCode.LoadLevel(1);




        inputCheck();



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

    void inputCheck()
    {
        int connectedDevices = 0;
        string[]joyStickNamesArray = Input.GetJoystickNames();
        foreach (string input in joyStickNamesArray)
        {
            if (input.Length != 0)
            {
                connectedDevices++;
            }
        }
        
        string[] test = new string[connectedDevices];
        int j = 0;
        for (int i = 0; i < Input.GetJoystickNames().Length; i++)
        {
            if (joyStickNamesArray[i].Length != 0)
            {
                test[j] = joyStickNamesArray[i];
                j++;
            }
        }

        for (int i = 0; i <= 1; i++)
        {
            if (i < test.Length)
            {
                if (test[i] != "Dance Pad (Konami Dance Pad)")
                    sceneCode.LoadLevel(0);
            }
            else
                sceneCode.LoadLevel(0);
        }
        for (int i = 2; i <= 3; i++)
        {
            if (i < test.Length)
            {
                if (test[i] != "Controller (XBOX 360 For Windows)")
                    sceneCode.LoadLevel(0);
            }
            else
                sceneCode.LoadLevel(0);
        }
    }
}
