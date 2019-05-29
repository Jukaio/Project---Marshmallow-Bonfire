using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    public CheckpointController controller;

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (gameObject.CompareTag("redTile") && collision.gameObject.CompareTag("bluePlayer") || gameObject.CompareTag("blueTile") && collision.gameObject.CompareTag("redPlayer"))
    //    {
    //        if (collision.gameObject.GetComponent<State>().currentState != State.States.IN_GRAB)
    //        {
    //            collision.transform.position = controller.currentPoint;
    //        }  
    //    }
    //}

    //public void KnockbackObj(GameObject obj)
    //{
    //    obj.GetComponent<Rigidbody2D>().AddForce(knockback, ForceMode2D.Impulse);
    //}

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (gameObject.CompareTag("redTile") && collision.gameObject.CompareTag("bluePlayer"))
    //    {
    //        KnockbackObj(collision.gameObject);
    //    }
    //    else if (gameObject.CompareTag("blueTile") && collision.gameObject.CompareTag("redPlayer"))
    //    {
    //        KnockbackObj(collision.gameObject);
    //    }
    //}
}
