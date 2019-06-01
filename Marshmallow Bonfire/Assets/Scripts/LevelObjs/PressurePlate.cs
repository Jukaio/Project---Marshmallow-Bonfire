using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public GameObject wallSprite;
    public GameObject wallCollider;

    Animator plateAnim;
    Animator wallAnim;

    void Start()
    {
        plateAnim = GetComponent<Animator>();
        wallAnim = wallSprite.GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("redPlayer") || collision.gameObject.CompareTag("bluePlayer"))
        {
            wallAnim.Play("Open");
            plateAnim.Play("Press");
            wallCollider.SetActive(false);
        }
    }
}
