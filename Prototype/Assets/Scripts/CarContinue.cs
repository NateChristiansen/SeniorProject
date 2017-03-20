using UnityEngine;
using System.Collections;

public class CarContinue : MonoBehaviour
{
    public StopCar Stopper;
    public DriverControl Controller;
    public ShipGrow Grow;
    public RG_IKDriver Driver;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider col)
    {
        Stopper.Continue = true;
        Controller.SolvedScenario = false;
        Driver.FootPosition = RG_IKDriver.FootState.Gas;
        Grow.Grow = false;
        Grow.ScaleTo = 0;
        Grow.Activate = true;
    }
}
