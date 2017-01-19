using UnityEngine;
using System.Collections;

public class GoodSelectionHandler : AbstractScenarioHandler, IGvrGazeResponder {

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
        GameObject.Find("Vehicle").gameObject.GetComponent<AbstractScenario>().SetSelectionResult("good");
        GameObject.Find("Vehicle").gameObject.GetComponent<AbstractScenario>().SetSelectionMade(true);
        ColorChoice();
    }
}
