﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayTrigger : MonoBehaviour
{
    Animator anim;
    public bool temp;

    private void Start()
    {
        anim = GetComponent<Animator>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("redPlayer") || collision.gameObject.CompareTag("bluePlayer"))
        {


        }
    }
}
