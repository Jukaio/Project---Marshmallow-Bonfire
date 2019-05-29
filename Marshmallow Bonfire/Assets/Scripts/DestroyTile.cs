using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DestroyTile : MonoBehaviour
{
    Tilemap tilemap;
    Vector3 tilePos;

    private void Start()
    {
        tilemap = GameObject.FindGameObjectWithTag("breakable").GetComponent<Tilemap>();
    }

    void OnCollisionStay2D(Collision2D collision)
    {
         DestroyTiles(collision);
    }

    void DestroyTiles(Collision2D collision)
    {
        foreach (ContactPoint2D collisionPoint in collision.contacts)
        {
            tilePos.x = collisionPoint.point.x - 0.01f * collisionPoint.normal.x;
            tilePos.y = collisionPoint.point.y - 0.01f * collisionPoint.normal.y;
            tilemap.SetTile(tilemap.WorldToCell(tilePos), null);
        }
    }
}
