using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private CheckpointController controller;

    private void Start()
    {
        controller = GetComponentInParent<CheckpointController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("redPlayer"))
        {
            controller.redCurrentPoint = new Vector3(collision.transform.position.x, collision.transform.position.y, 0f);
        }
        else if (collision.CompareTag("bluePlayer"))
        {
            controller.blueCurrentPoint = new Vector3(collision.transform.position.x, collision.transform.position.y, 0f);
        }
        
    }
}
