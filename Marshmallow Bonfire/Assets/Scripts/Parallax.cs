using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{

    public GameObject ALayer1;
    public GameObject ALayer2;

    public GameObject BLayer1;
    public GameObject BLayer2;

    Vector2 origin1;
    Vector2 origin2;

    public Camera camera;

    void Start()
    {
        origin1 = BLayer1.transform.position;
        origin2 = BLayer2.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.L))
        {
            ALayer2.transform.Translate(Vector2.left / 100);
            BLayer2.transform.Translate(Vector2.left / 100);

            ALayer1.transform.Translate(Vector2.left / 75);
            BLayer1.transform.Translate(Vector2.left / 75);
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.J))
        {
            ALayer2.transform.Translate(Vector2.right / 100);
            BLayer2.transform.Translate(Vector2.right / 100);

            ALayer1.transform.Translate(Vector2.right / 75);
            BLayer1.transform.Translate(Vector2.right / 75);
        }

        if(ALayer1.transform.position.x + (camera.orthographicSize * camera.aspect) <= camera.transform.position.x - (camera.orthographicSize * camera.aspect))
        {
            ALayer1.transform.position = origin1;
        }
        
        
    }
}
