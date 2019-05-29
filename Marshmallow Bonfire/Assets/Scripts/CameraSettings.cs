using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSettings : MonoBehaviour
{
    class Data
    {
        public float position;
        public float size;

        public Data(float position, float size)
        {
            this.position = position;
            this.size = size;
        }
    }

    Camera mainCamera;
    Vector2 cameraSize;
    public Vector2 cameraOffset;

    public GameObject bluePlayer;
    public GameObject redPlayer;

    GameObject invisPlayer;
    public float distancePlayers;

    SpawnLevel levelSpawner;
    Data groundData;
    Data leftData;
    Data topData;
    Data rightData;

    public enum Frame
    {
        Ground,
        Left,
        Top,
        Right
    }

    private void Start()
    {
        mainCamera = GetComponent<Camera>();
       
        mainCamera.nearClipPlane = 0;

        cameraSize = new Vector2(mainCamera.aspect * mainCamera.orthographicSize, mainCamera.orthographicSize);

        mainCamera.orthographic = true;

        for (int i = 0; i < transform.parent.childCount; i++)
        {
            if (transform.parent.GetChild(i).GetComponent<SpawnLevel>() != null)
            {
                levelSpawner = transform.parent.GetChild(i).GetComponent<SpawnLevel>();
            }
        }

        groundData = new Data(levelSpawner.levelBuildData[(int)Frame.Ground].cooridnates.y, levelSpawner.levelBuildData[(int)Frame.Ground].colliderSize.y);
        leftData = new Data(levelSpawner.levelBuildData[(int)Frame.Left].cooridnates.x, levelSpawner.levelBuildData[(int)Frame.Left].colliderSize.x);
        topData = new Data(levelSpawner.levelBuildData[(int)Frame.Top].cooridnates.y, levelSpawner.levelBuildData[(int)Frame.Top].colliderSize.y);
        rightData = new Data(levelSpawner.levelBuildData[(int)Frame.Right].cooridnates.x, levelSpawner.levelBuildData[(int)Frame.Right].colliderSize.x);


        invisPlayer = new GameObject("invis Player");
        invisPlayer.transform.parent = redPlayer.transform.parent;
        StartCoroutine(CreateDistancePoint());
    }

    private void Update()
    {
        if (redPlayer.transform.position.x - cameraSize.x <= leftData.position) //Horizontal
        {
            transform.position = new Vector2(leftData.position + cameraSize.x + cameraOffset.x, transform.position.y);

        }
        else if (redPlayer.transform.position.x + cameraSize.x >= rightData.position)
        {
            transform.position = new Vector2(rightData.position - cameraSize.x - cameraOffset.x, transform.position.y);
        }
        else
            transform.position = new Vector2(redPlayer.transform.position.x, transform.position.y); //invis player == camera point for adjustment

        if (redPlayer.transform.position.y <= groundData.position + cameraSize.y + cameraOffset.y) //Vertical 
        {
            transform.position = new Vector2(transform.position.x, groundData.position + cameraSize.y - cameraOffset.y);

        }
        else if (redPlayer.transform.position.y >= topData.position - cameraSize.y)
        {
            transform.position = new Vector2(transform.position.x, topData.position - cameraSize.y + topData.size);

        }
        else
            transform.position = new Vector2(transform.position.x, redPlayer.transform.position.y);
    }

    IEnumerator CreateDistancePoint()
    {
        while(true)
        {
            //distancePoint = new Vector2(redPlayer.transform.position.x - bluePlayer.transform.position.x, redPlayer.transform.position.y);

            //distancePlayers = Vector2.Distance(redPlayer.transform.position, bluePlayer.transform.position);
            //if(redPlayer.transform.position.x <= bluePlayer.transform.position.x)
            //{
            //    invisPlayer.transform.position = distancePoint;
            //    Debug.Log("red left");
            //}
            //else
            //{
            //    invisPlayer.transform.position = distancePoint;
            //    Debug.Log("blue left");
            //}
            yield return new WaitForEndOfFrame();
        }
    }
   
}
