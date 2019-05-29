using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour
{

    SceneScripts scriptsScene;

    private void Start()
    {
        scriptsScene = GetComponent<SceneScripts>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            scriptsScene.ReloadScene();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        scriptsScene.LoadLevel(0);
    }
}
