using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour
{
    State state;
    State otherState;

    public GameObject otherPlayer;
    Mechanics mechanics;
    Command command;

    private void Awake()
    {
        state = GetComponent<State>();
        mechanics = GetComponent<Mechanics>();
        command = GetComponent<Command>();

        otherState = state.otherState;
        otherPlayer = state.otherPlayer;
    }

    public States Main_Grab(States currentState)
    {
        if (otherPlayer.transform.position.x < transform.position.x)
            otherState.currentState = States.IN_GRAB_LEFT;
        else
            otherState.currentState = States.IN_GRAB_RIGHT;

        mechanics.GrabAttach(gameObject, otherPlayer);
        if (!command.Grab()) //grab key
        {
            mechanics.GrabDeattach(otherPlayer);
            return States.IDLE;
        }
        else if (command.MoveLeft()) //move key
        {
            return States.GRAB_MOVE_LEFT; //GrabMoveLeft
        }
        else if (command.MoveRight()) //move key
        {
            return States.GRAB_MOVE_RIGHT; //GrabMoveRight
        }
        return currentState;
    }

    public States Grab_Move_Left(States currentState)
    {
        mechanics.MoveLeft();
        if (!command.Grab()) //grab key
        {
            mechanics.GrabDeattach(otherPlayer);
            return States.IDLE;
        }
        else if (!command.MoveLeft()) //move key
        {
            return States.GRAB; //GrabMoveLeft
        }
        else if (command.MoveRight()) //move key
        {
            return currentState; //GrabMoveRight
        }
        return currentState;
    }

    public States Grab_Move_Right(States currentState)
    {
        mechanics.MoveRight();
        if (!command.Grab()) //grab key
        {
            mechanics.GrabDeattach(otherPlayer);
            return States.IDLE;
        }
        else if (!command.MoveRight()) //move key
        {
            return States.GRAB; //GrabMoveLeft
        }
        else if (command.MoveLeft()) //move key
        {
            return currentState; //GrabMoveRight
        }
        return currentState;
    }
}
