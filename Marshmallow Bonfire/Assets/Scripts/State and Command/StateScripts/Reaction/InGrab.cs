using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGrab : MonoBehaviour
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

    public States Main_InGrab(States currentState)
    {
        if (otherState.currentState != States.GRAB)
        {
            mechanics.GrabDeattach(otherPlayer);
            return States.IDLE;
        }
        return currentState;
    }
}
