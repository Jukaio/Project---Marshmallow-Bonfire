using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    SceneScripts scriptsScene;
    public bool redOnPortal;
    public bool blueOnPortal;

    private void Start()
    {
        scriptsScene = GetComponent<SceneScripts>();
    }

    private void Update()
    {
        if (blueOnPortal && redOnPortal)
        {
            StartCoroutine(Load());
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("redPlayer"))
        {
            redOnPortal = true;
        }
        else if (collision.gameObject.CompareTag("bluePlayer"))
        {
            blueOnPortal = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("redPlayer"))
        {
            redOnPortal = false;
        }
        else if (collision.gameObject.CompareTag("bluePlayer"))
        {
            blueOnPortal = false;
        }
    }

    IEnumerator Load()
    {
        yield return new WaitForSeconds(1);
        scriptsScene.LoadNextLevel();
    }
}
