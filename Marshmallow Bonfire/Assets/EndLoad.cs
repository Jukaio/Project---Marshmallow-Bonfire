using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLoad : MonoBehaviour
{
    SceneScripts scriptsScene;

    void Start()
    {
        scriptsScene = GetComponent<SceneScripts>();
        StartCoroutine(Load());
    }

    IEnumerator Load()
    {
        yield return new WaitForSeconds(6);
        scriptsScene.LoadLevel(1);
    }
}
