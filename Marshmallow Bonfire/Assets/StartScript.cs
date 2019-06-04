using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScript : MonoBehaviour
{
    public Animator animator;
    SceneScripts scriptsScene;
    Command command;

    void Start()
    {
        scriptsScene = GetComponent<SceneScripts>();
        command = GetComponent<Command>();
    }

    private void Update()
    {
        if (command.startGame())
        {
            StartCoroutine(Load());
        }
    }

    IEnumerator Load()
    {
        animator.SetTrigger("FadeIn");
        yield return new WaitForSeconds(2);
        scriptsScene.LoadLevel(2);
    }
}
