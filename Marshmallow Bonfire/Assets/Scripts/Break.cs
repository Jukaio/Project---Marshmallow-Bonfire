using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Break : MonoBehaviour
{

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("fireball"))
        {
            gameObject.SetActive(false);
        }
    }
}
