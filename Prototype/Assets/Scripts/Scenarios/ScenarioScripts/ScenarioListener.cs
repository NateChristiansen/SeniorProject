using UnityEngine;
using System.Collections;
using System.Threading;

public class ScenarioListener : MonoBehaviour {

    public string GoodChoiceText;
    public string BadChoiceText;
    public string DefaultChoiceText;
    public float Time;

    private static string _triggerName;

    // determine the scenario type
    void OnCollisionEnter(Collision col)
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
