using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deactivate : MonoBehaviour
{
    public GameObject obj;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("redPlayer") || collision.gameObject.CompareTag("bluePlayer"))
        {
            obj.SetActive(false);
        }
    }
}
