using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateObj : MonoBehaviour
{
    public GameObject obj;
    private bool active;

    void Start()
    {
        active = false; 
        obj.SetActive(active);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        active = !active;
        obj.SetActive(active);
    }

}
