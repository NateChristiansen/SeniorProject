using UnityEngine;
using System.Collections;

public class AbstractScenarioHandler : MonoBehaviour, IScenarioSelectionHandler
{
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    protected void ColorChoice()
    {
        foreach (Transform child in GameObject.Find("ScenarioMenu").transform)
        {
            child.gameObject.GetComponent<Renderer>().material.color = Color.white;
        }
        this.GetComponent<Renderer>().material.color = Color.yellow;
    }

}
