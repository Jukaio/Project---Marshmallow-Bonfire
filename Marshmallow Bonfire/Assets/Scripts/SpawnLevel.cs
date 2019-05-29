using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class WorldFrameNode
{
    GameObject WorldFrameObject;

    Sprite terrain;

    float x, y;

    public WorldFrameNode(string objectName, Transform parent, Vector2 position, Vector2 colliderSize)
    {
        GameObject obj = new GameObject(objectName);
        obj.AddComponent<BoxCollider2D>().size = colliderSize;
        obj.transform.parent = parent;
        obj.transform.position = position;
    }
}

public struct objectInformation
{
    public string name;
    public Vector2 cooridnates;
    public Vector2 colliderSize;

    public objectInformation(Vector2 position, Vector2 sizeCollider, string name)
    {
        this.name = name;
        cooridnates = position;
        colliderSize = sizeCollider;
    }
}



public class SpawnLevel : MonoBehaviour
{
    GameManager gameManager;

    Sprite frameSprite;

    public int levelHorSize = 22;
    public int levelVertSize = 12;

    public List<WorldFrameNode> worldFrameList = new List<WorldFrameNode>();
    public List<objectInformation> levelBuildData = new List<objectInformation>();

    List<GameObject> frameGroundList = new List<GameObject>();
    List<GameObject> frameTopList = new List<GameObject>();
    List<GameObject> frameLeftList = new List<GameObject>();
    List<GameObject> frameRightList = new List<GameObject>();
    public Camera mainCamera;

    void Start()
    {
        frameSprite = Resources.Load<Sprite>("placeholderGreen");

        PrepareInformation();

        levelBuildData = PrepareWorldFrameData(levelBuildData);


    }

    void PrepareInformation()
    {
        gameManager = transform.parent.gameObject.GetComponent<GameManager>();
        mainCamera = GameObjectExtensions.GetTInChildren<Camera>(gameManager.gameObject);
    }

    
    List<objectInformation> PrepareWorldFrameData(List<objectInformation> levelBuildData)
    {
        levelBuildData.Add(new objectInformation(new Vector2(transform.position.x, -levelVertSize),
            new Vector2(22 * 2f, 1f), "Ground"));
        levelBuildData.Add(new objectInformation(new Vector2(-levelHorSize, transform.position.x),
            new Vector2(1f, 12 * 2f), "Left"));
        levelBuildData.Add(new objectInformation(new Vector2(transform.position.x, levelVertSize),
            new Vector2(22 * 2f, 1f), "Top"));
        levelBuildData.Add(new objectInformation(new Vector2(levelHorSize, transform.position.x),
            new Vector2(1f, 12 * 2f), "Right"));
        return levelBuildData;
    }

    void BuildWorldFrame()
    {
        for (int i = 0; i < levelBuildData.Count; i++)
        {
            worldFrameList.Add(new WorldFrameNode(levelBuildData[i].name, transform, levelBuildData[i].cooridnates, levelBuildData[i].colliderSize));
        }
    }
    
    void DrawWorldFrame()
    {
        GameObject[] frameParents = { new GameObject("Ground"),
        new GameObject("Top"),
        new GameObject("left"),
        new GameObject("right")};

        foreach (GameObject obj in frameParents)
        {
            obj.transform.parent = transform;
        }

        for (int i = -levelHorSize; i <= levelHorSize ; i++)
        {
            frameGroundList.Add(new GameObject("Ground" + i));
            frameGroundList[i + levelHorSize].transform.parent = transform;
            frameGroundList[i + levelHorSize].AddComponent<SpriteRenderer>().sprite = frameSprite;
            frameGroundList[i + levelHorSize].transform.position = new Vector2(i, -levelVertSize);
            frameGroundList[i + levelHorSize].transform.parent = frameParents[0].transform;

            frameTopList.Add(new GameObject("Ground" + i));
            frameTopList[i + levelHorSize].transform.parent = transform;
            frameTopList[i + levelHorSize].AddComponent<SpriteRenderer>().sprite = frameSprite;
            frameTopList[i + levelHorSize].transform.position = new Vector2(i, levelVertSize);
            frameTopList[i + levelHorSize].transform.parent = frameParents[1].transform;
        }

        for (int i = -levelVertSize; i <= levelVertSize; i++)
        {
            frameLeftList.Add(new GameObject("Left" + i));
            frameLeftList[i + levelVertSize].transform.parent = transform;
            frameLeftList[i + levelVertSize].AddComponent<SpriteRenderer>().sprite = frameSprite;
            frameLeftList[i + levelVertSize].transform.position = new Vector2(-levelHorSize, i);
            frameLeftList[i + levelVertSize].transform.parent = frameParents[2].transform;

            frameRightList.Add(new GameObject("Right" + i));
            frameRightList[i + levelVertSize].transform.parent = transform;
            frameRightList[i + levelVertSize].AddComponent<SpriteRenderer>().sprite = frameSprite;
            frameRightList[i + levelVertSize].transform.position = new Vector2(levelHorSize, i);
            frameRightList[i + levelVertSize].transform.parent = frameParents[3].transform;
        }

    }


}
