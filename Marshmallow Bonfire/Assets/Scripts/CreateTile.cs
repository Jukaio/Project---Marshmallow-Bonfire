using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class CreateTile : MonoBehaviour
{
    Tilemap tilemap;
    public Tile tile;

    private Vector3 tilePos;
    public Vector2 position;

    private void Start()
    {
        tilemap = GameObject.FindGameObjectWithTag("breakable").GetComponent<Tilemap>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        print("colllide");
        CreateTiles(position);
        gameObject.SetActive(false);
    }

    void CreateTiles(Vector2 position)
    {
        tilePos.x = gameObject.transform.position.x - 0.01f * gameObject.transform.position.x + position.x;
        tilePos.y = gameObject.transform.position.y - 0.01f * gameObject.transform.position.y + position.y;
        if (tilemap.GetTile(tilemap.WorldToCell(tilePos)) == null)
        {
            tilemap.SetTile(tilemap.WorldToCell(tilePos), tile);
        }
    }
}
