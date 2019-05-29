using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPosition : MonoBehaviour
{
    public Transform Spawner;
    public int test = 0;


    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "ground")
        {
            test = 0;
        }
        else if(collision.gameObject.tag == "redTile")
        {
            test = 1;
        }
    }
}
