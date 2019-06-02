using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnWrongGround : MonoBehaviour
{
    Mechanics mechanics;
    Command command;

    private void Awake()
    {
        mechanics = GetComponent<Mechanics>();
        command = GetComponent<Command>();
    }

    public States Main_WrongGround(States currentState, States otherState)
    {
        if (otherState != States.GRAB_MOVE_LEFT &&
            otherState != States.GRAB_MOVE_RIGHT &&
            otherState != States.GRAB)
        {
            mechanics.RespawnOnPosition();
        }
        return currentState;
    }
}
