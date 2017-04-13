using UnityEngine;
using System.Collections;

public class ScenarioDecider : MonoBehaviour
{
    public RG_IKDriver Driver;
    public RG_IKDriver.LookState Direction;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "car" && Direction == Driver.LookTarget)
        {
            GlobalValues.GetInstance().AddToScenarioCompletionTotal();
        }
    }
}
