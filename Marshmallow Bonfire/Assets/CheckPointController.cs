using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointController : MonoBehaviour
{
    public List<bool> checkPoints = new List<bool>();


    void Start()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i);
        }
    }

    void Update()
    {
        
    }
}
