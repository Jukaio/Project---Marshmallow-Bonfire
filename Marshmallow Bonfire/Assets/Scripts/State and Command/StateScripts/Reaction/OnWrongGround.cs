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

    public States Main_WrongGround(States currentState)
    {
        if (currentState != States.IN_GRAB &&
            currentState != States.IN_CHARGE &&
            currentState != States.IN_THROW)
        {
            mechanics.RespawnOnPosition();
        }
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
        {
            mechanics.RespawnOnPosition();
        }
        return currentState;
    }
}
