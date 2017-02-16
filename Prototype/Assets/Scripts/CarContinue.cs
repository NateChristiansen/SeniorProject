using UnityEngine;
using System.Collections;

public class CarContinue : MonoBehaviour
{
    public StopCar Stopper;
    public DriverControl Controller;
    public ShipGrow Grow;
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
        Grow.Grow = false;
        Grow.ScaleTo = 0;
        Grow.Activate = true;
    }
}
