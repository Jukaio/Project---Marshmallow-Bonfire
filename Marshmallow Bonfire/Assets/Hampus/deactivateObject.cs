using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deactivateObject : MonoBehaviour
{
    public GameObject obj;
    private bool inactive;

    void Start()
    {
        inactive = false;
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        inactive = !inactive;
        obj.SetActive(inactive);
    }

}
