using UnityEngine;
using System.Collections;
using System.Threading;

public class ScenarioListener : MonoBehaviour {

    public string GoodChoiceText;
    public string BadChoiceText;
    public string DefaultChoiceText;
    public float Time;

    // determine the scenario type
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "StopSignScenarioTrigger")
        {
            var stop = gameObject.AddComponent<StopSignScenario>();
            stop.GoodChoiceText = GoodChoiceText;
            stop.BadChoiceText = BadChoiceText;
            stop.DefaultChoiceText = DefaultChoiceText;
            stop.Timer = Time;
            stop.ScenarioIdentifier = "StopSignScenarioTrigger";
        }
        if (col.gameObject.name == "PassengerScenarioTrigger")
        {
            var stop = gameObject.AddComponent<PassengerScenario>();
            stop.GoodChoiceText = GoodChoiceText;
            stop.BadChoiceText = BadChoiceText;
            stop.DefaultChoiceText = DefaultChoiceText;
            stop.Timer = Time;
            stop.ScenarioIdentifier = "StopSignScenarioTrigger";
        }
    }

	// Use this for initialization
	void Start () 
    {
        
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}
}
