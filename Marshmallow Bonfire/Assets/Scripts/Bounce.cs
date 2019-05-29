using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    public float bounce;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("redPlayer") || collision.gameObject.CompareTag("bluePlayer"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = transform.up * bounce;
        }
    }
}
