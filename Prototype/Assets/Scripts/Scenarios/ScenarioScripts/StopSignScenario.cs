using System;
using UnityEngine;
using System.Collections;

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
        Debug.Log("GOOD MADE");
        this.enabled = false;
    }

    // the result of a bad choice
    public override void BadResult()
    {
        Debug.Log("BAD MADE");
        this.enabled = false;
    }

    // the rersult of a default choice
    public override void DefaultResult()
    {
        Debug.Log("DEFAULT MADE");
        this.enabled = false;
    }

	// Update is called once per frame
	void Update ()
	{
        base.Update();
	}

    
}
