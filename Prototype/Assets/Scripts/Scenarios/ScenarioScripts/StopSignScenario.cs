using System;
using UnityEngine;
using System.Collections;
using UnityTest;

public class StopSignScenario : MonoBehaviour//AbstractScenario
{
    public RG_IKDriver Driver;
    public StopObject Stop;
    // Use this for initialization
	void Start ()
	{
	}

	// Update is called once per frame
	void Update ()
	{
	}

    void OnTriggerEnter(Collider col)
    {
        if (Driver.LookTarget == RG_IKDriver.LookState.Straight)
        {
            Stop.ChoiceIsGood = true;
        }
    }
}
