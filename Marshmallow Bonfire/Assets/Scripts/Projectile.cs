using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public void MoveProjectile(Vector2 direction)
    {
        gameObject.SetActive(true);
        GetComponent<Rigidbody2D>().AddForce(direction, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.CompareTag("breakable") && collision.gameObject.CompareTag("fireball"))
        {
            gameObject.SetActive(false);
        }
        else if (!collision.gameObject.CompareTag("redPlayer") &&
                 !collision.gameObject.CompareTag("bluePlayer") &&
                 !collision.gameObject.CompareTag("breakable") && gameObject.CompareTag("fireball"))
        {
            gameObject.SetActive(false);
        }
    }
}
