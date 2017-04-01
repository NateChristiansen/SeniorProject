using UnityEngine;
using System.Collections;

public class StopCar : MonoBehaviour
{
    [HideInInspector]
    public bool Continue, Stop;
    public RG_IKDriver Driver;
    public MoveCar DriverCar;
    private float originalspeed;
    public DriverControl Controller;
    public bool IsTimed;
    public float TimeStopped;
    private float _timeStopped;
    private bool _isActive;

	// Use this for initialization
	void Start ()
	{
	    originalspeed = DriverCar.Speed;
	    _timeStopped = TimeStopped;
	}
	
	// Update is called once per frame
	void Update ()
	{
	    if (Stop && !Continue && _isActive)
	    {
	        DriverCar.Speed = 0;
	        TimeStopped -= Time.deltaTime;
	    }
	    if (TimeStopped <= 0)
	    {
	        Stop = false;
	        Continue = true;
	    }
	    if (!Stop && Continue && _isActive)
	    {
	        _isActive = false;
	        Controller.SolvedScenario = false;
	        Driver.FootPosition = RG_IKDriver.FootState.Gas;
            DriverCar.Speed = originalspeed;
	    }

	    if (Stop && Driver.LookTarget != RG_IKDriver.LookState.Straight)
            Stop = false;
	}

    public void Restart()
    {
        TimeStopped = _timeStopped;
    }

    void OnTriggerEnter(Collider col)
    {
        if (Driver.LookTarget == RG_IKDriver.LookState.Straight)
        {
            _isActive = true;
            Stop = true;
            Controller.SolvedScenario = true;
            Driver.FootPosition = RG_IKDriver.FootState.Brake;
        }
    }
}
