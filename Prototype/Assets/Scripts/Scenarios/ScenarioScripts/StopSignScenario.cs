using System;
using UnityEngine;
using System.Collections;
using UnityEditor;

public class StopSignScenario : AbstractScenario
{
    // Use this for initialization
	void Start ()
	{
        base.Start();
	}

    // the result of a good choice
    public override void GoodResult()
    {
        GameObject.Find("StopObject").GetComponent<StopObject>().ChoiceIsGood = true;
        this.enabled = false;
    }

    // the result of a bad choice
    public override void BadResult()
    {
        GameObject.Find("StopObject").GetComponent<StopObject>().ChoiceIsGood = false;
        this.enabled = false;
    }

	// Update is called once per frame
	void Update ()
	{
        base.Update();
	}

    
}
