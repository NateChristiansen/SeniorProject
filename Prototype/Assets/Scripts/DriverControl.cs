using UnityEngine;
using System.Collections;
using System;

public class DriverControl : MonoBehaviour, IGvrGazeResponder
{
    public RG_IKDriver Driver;
    private bool isLooking;
    private double time;
    private double scoretime = GlobalValues.ScoreTick;
    public void OnGazeEnter()
    {
        Driver.LookTarget = RG_IKDriver.LookState.Straight;
        isLooking = true;
    }

    public void OnGazeExit()
    {
        isLooking = false;
        time = 2;
    }

    public void OnGazeTrigger()
    {
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (!isLooking && time > 0)
	    {
	        time -= Time.deltaTime;
            if (time <= 0)
            {
                Driver.LookTarget = RG_IKDriver.LookState.Down;
            }
        }
	    if (scoretime > 0)
	    {
	        scoretime -= Time.deltaTime;
	    }
	    else
        {
            if (Driver.LookTarget == RG_IKDriver.LookState.Down)
                GlobalValues.Score += 1;
            else
                GlobalValues.Score -= 2;
            scoretime = GlobalValues.ScoreTick;
            Debug.Log(GlobalValues.Score);
        }
	}
}
