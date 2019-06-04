using System.Collections;
using UnityEngine;

public class Throw : MonoBehaviour
{
    State state;
    State otherState;

    public GameObject otherPlayer;
    Mechanics mechanics;
    Command command;

    public GameObject chargeBar;

    public float chargeFactor = 0;
    bool charging = false;
    public float chargeTime = 0;

    private void Awake()
    {
        state = GetComponent<State>();
        mechanics = GetComponent<Mechanics>();
        command = GetComponent<Command>();

        otherState = state.otherState;
        otherPlayer = state.otherPlayer;

        for (int i = 0; i < transform.childCount; i++)
        {
            if(transform.GetChild(i).name == "Chargebar")
            chargeBar = transform.GetChild(i).gameObject;
        }
    }

    public States Main_Throw(States currentState)
    {
        mechanics.Throw(otherPlayer);
        return States.IDLE;
    }

    public States Main_Charge(States currentState, float maxChargeTime, float chargeRate)
    {
        if (!charging)
        {
            StartCoroutine(State_Charge(maxChargeTime, chargeRate));
        }
        if (charging)
            return currentState;
        return States.THROW_ANIMATION;
    }

    IEnumerator State_Charge(float maxChargeTime, float chargeRate)
    {
        charging = true;
        chargeFactor = 0;
        chargeTime = 0;
        otherState.currentState = States.IN_CHARGE;

        chargeBar.SetActive(true);
        while (command.ChargeThrow())
        {
            if (chargeTime <= maxChargeTime)
            {
                chargeFactor += Time.deltaTime / chargeRate;
                chargeTime += Time.deltaTime;
            }
            yield return new WaitForEndOfFrame();
        }
        chargeBar.SetActive(false);
        GetComponent<Mechanics>().ChargeThrow(GetComponent<State>().otherPlayer, chargeFactor);
        otherState.currentState = States.IN_FALL_UP;
        charging = false;
    }

}
