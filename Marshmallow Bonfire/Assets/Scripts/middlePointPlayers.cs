using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class middlePointPlayers : MonoBehaviour
{
    public Transform obj1;
    public Transform obj2;

    //public Image image;

    public float a;
    public float b;
    public float c;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3((obj1.position.x + obj2.position.x) / 2,
           (obj1.position.y + obj2.position.y) / 2, 0f);

        //a = 0;
        //b = obj2.position.y - obj1.position.y;
        //c = Vector2.Distance(obj1.transform.position, obj2.transform.position);


        //Debug.Log(Vector2.Distance(obj1.transform.position, obj2.transform.position));
        //Debug.Log(Mathf.Atan(0.49f));
        //Debug.Log("Angle: " + Mathf.Atan2(obj1.transform.position.y + obj2.transform.position.y, obj1.transform.position.x + obj2.transform.position.x));
        //Debug.Log("FUCK " + Mathf.Sin(30 * Mathf.PI / 180));
        //Debug.Log("ARC FUCK " + Mathf.Rad2Deg * Mathf.Asin(((b/c))));

        //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, (Mathf.Rad2Deg * Mathf.Asin(b / c))), Time.deltaTime);
        //if(obj1.transform.position.x < obj2.transform.position.x)
        //    image.transform.rotation = Quaternion.Euler(0, 0, (Mathf.Rad2Deg * Mathf.Asin(b / c)) - 90);
        //else
        //    image.transform.rotation = Quaternion.Euler(0, 0, (180 - Mathf.Rad2Deg * Mathf.Asin(b / c)) - 90);
        
    }
}
