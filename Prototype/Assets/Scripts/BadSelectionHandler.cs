using UnityEngine;
using System.Collections;

public class BadSelectionHandler : MonoBehaviour, IGvrGazeResponder {

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
        GameObject.Find("Vehicle").gameObject.GetComponent<StopSignScenario>().SetSelectionResult("bad");
        GameObject.Find("Vehicle").gameObject.GetComponent<StopSignScenario>().SetSelectionMade(true);
        ColorChoice();
    }

    void ColorChoice()
    {
        foreach (Transform child in GameObject.Find("ScenarioMenu").transform)
        {
            child.gameObject.GetComponent<Renderer>().material.color = Color.white;
        }
        this.GetComponent<Renderer>().material.color = Color.yellow;
    }
}
