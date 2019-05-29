using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    SceneScripts scriptsScene;
    public bool onPortal;
    public bool redOnPortal;
    public bool blueOnPortal;

    private void Update()
    {
        if (blueOnPortal && redOnPortal)
            if (Input.GetKey(KeyCode.Alpha1))
                scriptsScene.LoadRandom();
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
}
