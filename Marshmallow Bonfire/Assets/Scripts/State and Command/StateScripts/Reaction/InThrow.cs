using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InThrow : MonoBehaviour
{
    Mechanics mechanics;
    Command command;
    public float prevY;
    public float prevPrevY;
    bool firstLoop = true;

    private void Awake()
    {
        mechanics = GetComponent<Mechanics>();
        command = GetComponent<Command>();
    }

    public States Main_InThrow(GroundType groundType, States currentState)
    {
        if(firstLoop)
        {
            prevPrevY = transform.position.y - 20;
            prevY = transform.position.y - 10;
            firstLoop = false;
        }

        if (command.MoveLeft()) // move key
        {
            mechanics.MoveLeft_Air();
        }
        else if (command.MoveRight()) //move key
        {
            mechanics.MoveRight_Air();
        }

        if (prevPrevY >= transform.position.y)
        {
            firstLoop = true;
            return States.IN_FALL;
        }
        prevPrevY = prevY;
        prevY = transform.position.y;

        return States.IN_THROW;
    }
}
