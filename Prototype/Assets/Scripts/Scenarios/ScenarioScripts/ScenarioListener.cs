using UnityEngine;
using System.Collections;
using System.Threading;

public class ScenarioListener : MonoBehaviour
{

    private static string _triggerName;

    // determine the scenario type
    void OnTriggerEnter(Collider col)
    {
       _triggerName = col.gameObject.name;
    }

	// Use this for initialization
	void Start () 
    {
        
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    public string GetTriggerName()
    {
        return _triggerName;
    }
}
