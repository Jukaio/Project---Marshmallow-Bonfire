using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    public AudioClip GrabSound;
    private GameObject player;

    void Start()
    {
        player = null;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            GrabAttach();
        }
        else if (Input.GetKeyUp(KeyCode.X))
        {
            GrabDeattach();
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("redPlayer") || collision.CompareTag("bluePlayer"))
        {
            player = collision.gameObject;
        }
        SoundManager.instance.PlaySingle(GrabSound);
    }

    public void GrabAttach()
    {
        transform.parent = player.transform;
    }
    public void GrabDeattach()
    {
        transform.parent = null;
    }


}
