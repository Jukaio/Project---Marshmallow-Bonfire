using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    Animator anim;
    public GameObject obj;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("redPlayer") || collision.gameObject.CompareTag("bluePlayer"))
        {
            obj.SetActive(false);
            anim.Play("Lever");
        }
    }
}
