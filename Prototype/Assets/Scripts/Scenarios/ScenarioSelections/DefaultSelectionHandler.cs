using System;
using UnityEngine;
using System.Collections;

public class DefaultSelectionHandler : AbstractScenarioHandler, IGvrGazeResponder
{

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnGazeEnter()
    {
        
    }

    public void OnGazeExit()
    {
        
    }

    public void OnGazeTrigger()
    {
        string s = GameObject.Find("Vehicle").gameObject.GetComponent<ScenarioListener>().GetTriggerName();
        try
        {
            GameObject.Find(s).gameObject.GetComponent<AbstractScenario>().SetSelectionResult("default");
            GameObject.Find(s).gameObject.GetComponent<AbstractScenario>().SetSelectionMade(true);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        ColorChoice();
    }

}
