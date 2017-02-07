using UnityEngine;
using System.Collections;
using System;

public class DriverControl : MonoBehaviour, IGvrGazeResponder
{
    public RG_IKDriver Driver;
    public void OnGazeEnter()
    {
        Driver.LookTarget = RG_IKDriver.LookState.Straight;
    }

    public void OnGazeExit()
    {
        Driver.LookTarget = RG_IKDriver.LookState.Down;
    }

    public void OnGazeTrigger()
    {
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
