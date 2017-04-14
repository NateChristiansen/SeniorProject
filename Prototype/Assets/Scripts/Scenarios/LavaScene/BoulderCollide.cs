using UnityEngine;
using System.Collections;

public class BoulderCollide : MonoBehaviour {

    public bool Stop;
    public RG_IKDriver Driver;
    public MoveCar DriverCar;
    private float originalspeed;
    public DriverControl Controller;
    public float WaitTime; // set by user to be 5
    public AudioSource CrashSound;

    // Use this for initialization
    void Start()
    {
        Stop = false;
        originalspeed = DriverCar.Speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (Stop)
        {
            WaitTime -= Time.deltaTime; // count down
            DriverCar.Speed = 0;
        }

        if (WaitTime <= 0 && Stop)
        {
            Stop = false;
            DriverCar.Speed = originalspeed;
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag.Equals("boulder"))
        {
            // stop the car
            Stop = true;

            // play crash sound
            CrashSound.Play();
        }
    }
}
