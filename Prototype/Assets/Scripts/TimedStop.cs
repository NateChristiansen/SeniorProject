using UnityEngine;
using System.Collections;

public class TimedStop : MonoBehaviour {

    public bool Continue, Stop;
    public RG_IKDriver Driver;
    public MoveCar DriverCar;
    private float originalspeed;
    public DriverControl Controller;
    public float WaitTime;

    // Use this for initialization
    void Start()
    {
        originalspeed = DriverCar.Speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (Stop && !Continue)
            DriverCar.Speed = 0;
        else
            DriverCar.Speed = originalspeed;

        if (Stop && Driver.LookTarget != RG_IKDriver.LookState.Straight)
            Stop = false;
    }

    void OnTriggerEnter(Collider col)
    {
        if (Driver.LookTarget == RG_IKDriver.LookState.Straight)
        {
            Stop = true;
            Controller.SolvedScenario = true;
        }
    }
}
