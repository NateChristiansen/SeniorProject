using UnityEngine;
using System.Collections;

public class BadSelectionHandler : AbstractScenarioHandler, IGvrGazeResponder
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
        GameObject.Find(s).gameObject.GetComponent<AbstractScenario>().SetSelectionResult("bad");
        GameObject.Find(s).gameObject.GetComponent<AbstractScenario>().SetSelectionMade(true);
        ColorChoice();
    }
}
