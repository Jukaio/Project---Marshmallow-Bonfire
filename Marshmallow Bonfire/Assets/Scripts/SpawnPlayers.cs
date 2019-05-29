using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

//IF YOU MOVE IMAGES IN FOLDER ADJUST THE ASSETDATABASE CODE LINE 

public class SpawnPlayers : MonoBehaviour
{
    public GameObject playerRed;
    public GameObject playerBlue;

    public SpriteRenderer playerRedSpriteRenderer;
    public SpriteRenderer playerBlueSpriteRenderer;

    public Sprite redSprite;
    public Sprite blueSprite;

    public GameManager gameManager;

    void Start()
    {
        gameManager = transform.parent.gameObject.GetComponent<GameManager>();

        playerRedSpriteRenderer = GetComponent<SpriteRenderer>();
        playerBlueSpriteRenderer = GetComponent<SpriteRenderer>();

        playerRed = gameManager.GetComponent<GameManager>().GetRedPlayer();
        playerBlue = gameManager.GetComponent<GameManager>().GetBluePlayer();

        playerBlue.transform.position = new Vector2(22 * (-8f / 10f), (12 * (-4f / 5f)));
        playerRed.transform.position = new Vector2(22 * (-9f / 10f), (12 * (-4f / 5f)));


        //Find Image in Path
        blueSprite = Resources.Load<Sprite>("placeholderBlue");
        redSprite = Resources.Load<Sprite>("placeholderRed");

        playerRedSpriteRenderer = playerRed.GetComponent<SpriteRenderer>();
        playerBlueSpriteRenderer = playerBlue.GetComponent<SpriteRenderer>();

        playerRedSpriteRenderer.sprite = redSprite;
        playerBlueSpriteRenderer.sprite = blueSprite;
    }

    void Update()
    {
        
    }

}
