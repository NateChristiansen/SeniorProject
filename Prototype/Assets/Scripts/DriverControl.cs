using UnityEngine;
using System.Collections;
using System;

public class DriverControl : MonoBehaviour, IGvrGazeResponder
{
    public RG_IKDriver Driver;
    [HideInInspector]
    public bool IsLooking;
    [HideInInspector]
    public bool SolvedScenario = false;
    private double _time;
    public void OnGazeEnter()
    {
        Driver.LookTarget = RG_IKDriver.LookState.Straight;
        IsLooking = true;
    }

    public void OnGazeExit()
    {
        IsLooking = false;
        _time = 2;
    }

    public void OnGazeTrigger()
    {
    }

    // Use this for initialization
    void Start () {
	
	}

    public void Clear()
    {
        _time = 0;
    }
	
	// Update is called once per frame
	void Update () {
	    if (!(IsLooking || SolvedScenario) && _time > 0)
	    {
	        _time -= Time.deltaTime;
            if (_time <= 0)
            {
                Driver.LookTarget = RG_IKDriver.LookState.Down;
            }
        }
	}
}
