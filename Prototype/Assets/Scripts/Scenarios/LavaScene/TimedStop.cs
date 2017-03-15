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
        if (Stop == true)
            WaitTime -= Time.deltaTime; // count down

        if (Stop && !Continue)
            DriverCar.Speed = 0;
        else
            DriverCar.Speed = originalspeed;

        if (Stop && Driver.LookTarget != RG_IKDriver.LookState.Straight)
            Stop = false;

        if (WaitTime <= 0)
        {
            Stop = false;
            DriverCar.Speed = originalspeed;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (Driver.LookTarget == RG_IKDriver.LookState.Straight && col.gameObject.tag.Equals("car"))
        {
            Stop = true;
            Controller.SolvedScenario = true;
        }
    }
}
