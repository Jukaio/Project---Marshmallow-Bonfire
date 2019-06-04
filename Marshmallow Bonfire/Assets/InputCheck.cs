using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;
using UnityEngine.UI;


public class InputCheck : MonoBehaviour
{
    public Text DanceMatConnect1;
    public Text DanceMatConnect2;
    public Text GamePadConnected1;
    public Text GamePadConnected2;
    Text[] texts = new Text[4];
    SceneScripts sceneCode;

    public string[] test;
    public string[] joyStickNamesArray;

    public bool[] testBool = new bool[4];

    public int connectedDevices;

    // Start is called before the first frame update
    void Start()
    {
        sceneCode = GetComponent<SceneScripts>();
        texts[0] = DanceMatConnect1;
        texts[1] = DanceMatConnect2;
        texts[2] = GamePadConnected1;
        texts[3] = GamePadConnected2;
    }

    // Update is called once per frame
    void Update()
    {
        connectedDevices = 0;
        joyStickNamesArray = Input.GetJoystickNames();
        foreach (string input in joyStickNamesArray)
        {
            if (input.Length != 0)
            {
                connectedDevices++;
            }
        }

        testBool = new bool[connectedDevices];

        test = new string[connectedDevices];
        int j = 0;
        for (int i = 0; i < Input.GetJoystickNames().Length; i++)
        {
            if (joyStickNamesArray[i].Length != 0)
            {
                test[j] = joyStickNamesArray[i];
                j++;
            }
        }

        testBool = new bool[connectedDevices];

        for (int i = 0; i <= 1; i++)
        {
            if (i < test.Length)
            {
                if (test[i] != "Dance Pad (Konami Dance Pad)")
                    texts[i].color = Color.yellow;
                else if (test[i].Length != 0)
                {
                    texts[i].color = Color.green;
                }
                
            }
            else
                texts[i].color = Color.red;
        }
        for (int i = 2; i <= 3; i++)
        {
            if (i < test.Length)
            {
                 if (test[i] != "Controller (XBOX 360 For Windows)")
                    texts[i].color = Color.yellow;
                else if (test[i].Length != 0)
                {
                    texts[i].color = Color.green;
                }
            }
            else
                texts[i].color = Color.red;
        }

        int counter = 0;
        for (int i = 0; i <= 3; i++)
        {
            if(texts[i].color == Color.green)
            {
                counter++;
            }
        }
        if(counter == 4)
        {
            sceneCode.LoadLevel(1);
        }
    }

}
