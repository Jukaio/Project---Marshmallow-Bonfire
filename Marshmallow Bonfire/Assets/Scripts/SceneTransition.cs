using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTransition : MonoBehaviour
{
    Animator animator;
    SceneScripts scriptsScene;

    int levelIndex;

    void Start()
    {
        animator = GetComponent<Animator>();
        scriptsScene = GetComponent<SceneScripts>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            FadeInToLevel(3);
        }
    }

    public void FadeInToLevel(int index)
    {
        levelIndex = index;
        animator.SetTrigger("FadeIn");
    }

    public void FadeComplete()
    {
        scriptsScene.LoadLevel(levelIndex);
    }
}
