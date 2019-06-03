using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using XInputDotNetPure;
using System.IO;


public enum States
{
    IDLE,
    MOVE_LEFT,
    MOVE_RIGHT,
    GRAB,
    IN_GRAB_LEFT,
    THROW,
    IN_THROW,
    IN_CHARGE,
    IN_FALL,
    THROWING,
    GRAB_MOVE_LEFT,
    GRAB_MOVE_RIGHT,
    IN_GRAB_RIGHT,
    DUCK,
    TRY_TO_JUMP
}

public enum GroundType
{
    GREEN, //Later add more object tags here
    RED,
    BLUE,
    AIR
}

public class State : MonoBehaviour
{
    public Camera mainCamera;

    Animator anim;
    public string characterName;
    public GameObject Body_Side;
    public GameObject Body;


    GameObject walkingTrail;

    public string canNotMoveOn;
    public string canMoveOn;

    public GroundType groundType;
    public GroundType prevGroundType;
    public string GroundTypeString;
    public string prevGroundTypeString;

    public States currentState;
    public States prevState;
    private bool dirTemp;

    public GameObject otherPlayer;
    public State otherState;

    Mechanics mechanics;
    Mechanics otherMechanics;

    public bool grounded;

    bool inWait;


    void Start()
    {
        anim = GetComponent<Animator>(); 
        for(int i = 0; i < transform.childCount; i++)
        {
            if(transform.GetChild(i).GetComponent<ParticleSystem>() != null)
            {
                walkingTrail = transform.GetChild(i).gameObject;
                ParticleSystem.EmissionModule emissionModule;
                emissionModule = walkingTrail.GetComponent<ParticleSystem>().emission;
                emissionModule.rateOverTime = 10;
            }
        }

        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).name == name + "_Body_Side")
            {
                Body_Side = transform.GetChild(i).gameObject;
            }
            if (transform.GetChild(i).name == name + "_Body")
            {
                Body = transform.GetChild(i).gameObject;
            }
        }


        mechanics = GetComponent<Mechanics>();
        otherMechanics = otherPlayer.GetComponent<Mechanics>();

        otherState = otherPlayer.GetComponent<State>();

        changeLayerSorting(name);
    }

    void Update()
    {

        CheckGroundType();

        prevState = currentState;



        anim.SetInteger("index", (int)currentState);
        if(currentState == States.IN_GRAB_LEFT ||
            currentState == States.IN_GRAB_RIGHT)
        {
            Body.transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (dirTemp)
        {
            Body.transform.eulerAngles = new Vector3(0, 180, 0);
            Body_Side.transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else if (!dirTemp)
        {
            Body.transform.eulerAngles = new Vector3(0, 0, 0);
            Body_Side.transform.eulerAngles = new Vector3(0, 0, 0);
        }


    }

    void CheckGroundType()
    {
        if (gameObject.tag == "bluePlayer")
        {
            switch (groundType)
            {
                case GroundType.GREEN:
                    CheckState_Ground();
                    break;

                case GroundType.BLUE:
                    CheckState_Ground();
                    break;
                case GroundType.RED:
                    if (GetComponent<OnWrongGround>() == null)
                        gameObject.AddComponent<OnWrongGround>();
                    currentState = GetComponent<OnWrongGround>().Main_WrongGround(currentState, otherState.currentState);
                    break;

                case GroundType.AIR:
                    CheckState_Air();
                    break;
            }
        }
        else if (gameObject.tag == "redPlayer")
        {
            switch (groundType)
            {
                case GroundType.GREEN:
                    CheckState_Ground();
                    break;

                case GroundType.BLUE:
                    if (GetComponent<OnWrongGround>() == null)
                        gameObject.AddComponent<OnWrongGround>();
                    currentState = GetComponent<OnWrongGround>().Main_WrongGround(currentState, otherState.currentState);
                    break;
                case GroundType.RED:
                    CheckState_Ground();
                    break;

                case GroundType.AIR:
                    CheckState_Air();
                    break;
            }
        }
    }

    void CheckState_Ground()
    {
        switch (currentState)
        {
            case States.IDLE:
                if (GetComponent<Idle>() == null)
                    gameObject.AddComponent<Idle>();
                currentState = GetComponent<Idle>().Main_Idle(currentState);
                changeLayerSorting(name);
                break;

            case States.MOVE_LEFT:
                if(transform.position.x <= mainCamera.transform.position.x - mainCamera.aspect * mainCamera.orthographicSize)
                {
                    currentState = States.IDLE;
                    return;
                }

                if (GetComponent<Move>() == null)
                    gameObject.AddComponent<Move>();
                currentState = GetComponent<Move>().Main_Left(currentState, groundType);
                walkingTrail.SetActive(true);

                dirTemp = true;
                changeLayerSorting(name);
                return;

            case States.MOVE_RIGHT:
                if (transform.position.x >= mainCamera.transform.position.x + mainCamera.aspect * mainCamera.orthographicSize)
                {
                    currentState = States.IDLE;
                    return;
                }

                if (GetComponent<Move>() == null)
                    gameObject.AddComponent<Move>();
                currentState = GetComponent<Move>().Main_Right(currentState, groundType);
                walkingTrail.SetActive(true);

                dirTemp = false;
                changeLayerSorting(name);
                return;

            case States.GRAB:
                if (GetComponent<Grab>() == null)
                    gameObject.AddComponent<Grab>();
                currentState = GetComponent<Grab>().Main_Grab(currentState);
                changeLayerSorting(name);
                break;

            case States.GRAB_MOVE_LEFT:
                currentState = GetComponent<Grab>().Grab_Move_Left(currentState);
                changeLayerSorting(name);
                break;

            case States.GRAB_MOVE_RIGHT:
                currentState = GetComponent<Grab>().Grab_Move_Right(currentState);
                changeLayerSorting(name);
                break;

            case States.THROW:
                if (GetComponent<Throw>() == null)
                {
                    Throw temp = gameObject.AddComponent<Throw>();
                }
                currentState = GetComponent<Throw>().Main_Charge(currentState, mechanics.maxChargeTime, mechanics.chargeRate);
                changeLayerSorting(name);
                break;

            case States.IN_THROW:
                if (GetComponent<InThrow>() == null)
                    gameObject.AddComponent<InThrow>();
                currentState = GetComponent<InThrow>().Main_InThrow(groundType, currentState);
                changeLayerSorting("PlayerGrabbed");
                break;

            case States.IN_GRAB_LEFT:
                if (GetComponent<InGrab>() == null)
                    gameObject.AddComponent<InGrab>();
                currentState = GetComponent<InGrab>().Main_InGrab(currentState);
                changeLayerSorting("PlayerGrabbed");
                break;
            case States.IN_GRAB_RIGHT:
                if (GetComponent<InGrab>() == null)
                    gameObject.AddComponent<InGrab>();
                currentState = GetComponent<InGrab>().Main_InGrab(currentState);
                changeLayerSorting("PlayerGrabbed");
                break;

            case States.IN_CHARGE:
                changeLayerSorting("PlayerGrabbed");
                break;

            case States.THROWING:
                if (!inWait)
                    StartCoroutine(wait(1f / 60 * 20));
                break;

            case States.DUCK:
                if (GetComponent<Idle>() == null)
                    gameObject.AddComponent<Idle>();
                currentState = GetComponent<Idle>().Duck(currentState);
                break;

            case States.TRY_TO_JUMP:
                if (GetComponent<Idle>() == null)
                    gameObject.AddComponent<Idle>();
                currentState = GetComponent<Idle>().Try_To_Jump(currentState);
                break;

            default:
                currentState = States.IDLE;
                break;
        }

        walkingTrail.SetActive(false);
    }

    void CheckState_Air()
    {
        switch(currentState)
        {
            case States.IDLE:
                if (GetComponent<InThrow>() == null)
                    gameObject.AddComponent<InThrow>();
                currentState = GetComponent<InThrow>().Main_InThrow(groundType, currentState);


                break;

            case States.MOVE_LEFT:
                if (GetComponent<Move>() == null)
                    gameObject.AddComponent<Move>();
                currentState = GetComponent<Move>().Air_Left(currentState, groundType);

                dirTemp = true;

                break;

            case States.MOVE_RIGHT:
                if (GetComponent<Move>() == null)
                    gameObject.AddComponent<Move>();
                currentState = GetComponent<Move>().Air_Right(currentState, groundType);

                dirTemp = false;


                break;

            case States.IN_FALL:
                if (GetComponent<Idle>() == null)
                    gameObject.AddComponent<Idle>();
                currentState = GetComponent<Idle>().Air_Idle(currentState);
                break;

            case States.IN_THROW:
                if (GetComponent<InThrow>() == null)
                    gameObject.AddComponent<InThrow>();
                currentState = GetComponent<InThrow>().Main_InThrow(groundType, currentState);
                break;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "ground" || collision.gameObject.tag == "breakable" || collision.gameObject.tag == "draggable")
        {
            groundType = GroundType.GREEN;
        }
        else if (collision.gameObject.tag == "redTile")
        {
            groundType = GroundType.RED;
        }
        else if (collision.gameObject.tag == "blueTile")
        {
            groundType = GroundType.BLUE;
        }
        if(prevGroundType == GroundType.AIR)
        {
            Debug.Log("I LANDED!!");
        }

        prevGroundTypeString = collision.gameObject.tag;
        prevGroundType = groundType;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        groundType = GroundType.AIR;
        prevGroundType = groundType;
    }

    IEnumerator wait(float animLength)
    {
        inWait = true;
        yield return new WaitForSeconds(animLength);

        inWait = false;
        currentState = States.IDLE;

    }

    void changeLayerSorting(string layerName)
    {
        for (int i = 0; i < Body.transform.childCount; i++)
        {
            if (Body.transform.GetChild(i).GetComponent<SpriteRenderer>() != null)
            {
                Body.transform.GetChild(i).GetComponent<SpriteRenderer>().sortingLayerName = layerName;
            }
        }

        for (int i = 0; i < Body_Side.transform.childCount; i++)
        {
            if (Body_Side.transform.GetChild(i).GetComponent<SpriteRenderer>() != null)
            {
                Body_Side.transform.GetChild(i).GetComponent<SpriteRenderer>().sortingLayerName = layerName;
            }
        }
    }

} 