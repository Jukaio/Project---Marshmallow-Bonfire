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
        otherState.currentState = States.IN_GRAB;
        mechanics.GrabAttach(gameObject, otherPlayer);
        if (!command.Grab()) //grab key
        {
            mechanics.GrabDeattach(otherPlayer);
            return States.IDLE;
        }
        else if (command.MoveLeft()) //move key
        {
            mechanics.MoveLeft();
        }
        else if (command.MoveRight()) //move key
        {
            mechanics.MoveRight();
        }
        return currentState;
    }
}
