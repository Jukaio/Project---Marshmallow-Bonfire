using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameObjectExtensions 
{
    public static GameObject GetChildGameObjectWithComponent<TComponent>(this GameObject gameObject)
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
            if (gameObject.transform.GetChild(i).GetComponent<TComponent>() != null)
                return gameObject.transform.GetChild(i).gameObject;

        return null;
    }

    public static T GetTInChildren<T>(GameObject gameObject)
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            if (gameObject.transform.GetChild(i).GetComponent<T>() != null)
                return gameObject.transform.GetChild(i).GetComponent<T>();
            else
                Debug.LogError("Can't find component in Object " + gameObject.transform.GetChild(i).name + " (GetTInChildren GameManager.cs Line 17)");
        }
        Debug.LogError("Can't find component in children (GetTInChildren GameManager.cs Line 17)");
        return default;
    }
}

public class GameManager : MonoBehaviour
{
    public GameObject playerRed;
    public GameObject playerBlue;
    public GameObject playerParent;
    GameObject level;
    GameObject mainCamera;

    public Camera mainCameraComp;

    void Start()
    {

    }

    void Update()
    {

    }

    public GameObject GetRedPlayer()
    {
        return playerRed;
    }

    public GameObject GetBluePlayer()
    {
        return playerBlue;
    }

    public GameObject CheckForCamera(GameObject assignTo)
    {
        GameObject child = gameObject.GetChildGameObjectWithComponent<Camera>();

        if (child != null)
        {
            return assignTo = child;
        }
        return null;
    }

    public Camera GetCamera()
    {
        return mainCameraComp;  
    }

}
