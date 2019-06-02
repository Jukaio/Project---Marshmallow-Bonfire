using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : MonoBehaviour
{
    State state;

    public GameObject otherPlayer;
    State otherState;

    Command command;
    Mechanics mechanics;

    private void Awake()
    {
        state = GetComponent<State>();
        command = GetComponent<Command>();
        mechanics = GetComponent<Mechanics>();

        otherPlayer = state.otherPlayer;
        otherState = otherPlayer.GetComponent<State>();
    }

    public States Air_Idle(States currentState)
    {

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
    public States Main_Idle(States currentState)
    {
        if (command.MoveLeft()) //GamePad.GetState(PlayerIndex.One).DPad.Left == ButtonState.Pressed
        {
            return States.MOVE_LEFT;
        }
        else if (command.MoveRight())
        {
            return States.MOVE_RIGHT;
        }
        else if (command.Grab()) //grab key
        {
            if (mechanics.InRange(gameObject, otherPlayer))
            {
                return States.GRAB;
            }
        }
        else if (command.ChargeThrow()) // throw key
        {
            if (mechanics.InRange(gameObject, otherPlayer) && otherState.groundType != GroundType.AIR)
            {
                return States.THROW;
            }
        }
        else if (command.ButtonA())
        {
            mechanics.ShootProjectile(new Vector2(4f, 8));
        }
        else if (command.ButtonB())
        {
            mechanics.ShootProjectile(new Vector2(-4f, 8));
        }
        else if (command.ButtonX())
        {
            mechanics.ShootProjectile(new Vector2(8f, 4));
        }
        else if (command.ButtonY())
        {
            mechanics.ShootProjectile(new Vector2(-8, 4));
        }
        return currentState;
    }
}
