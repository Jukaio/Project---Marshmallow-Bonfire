using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InThrow : MonoBehaviour
{
    Mechanics mechanics;
    Command command;

    private void Awake()
    {
        mechanics = GetComponent<Mechanics>();
        command = GetComponent<Command>();
    }

    public States Main_InThrow(GroundType groundType, States currentState)
    {
        if (groundType != GroundType.AIR)
        {
            return States.IDLE;
        }
        if (command.MoveLeft()) // move key
        {
            mechanics.MoveLeft_Air();
        }
        else if (command.MoveRight()) //move key
        {
            mechanics.MoveRight_Air();
        }
        return currentState;
    }
}
