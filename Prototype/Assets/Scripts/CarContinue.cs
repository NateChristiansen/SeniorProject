using UnityEngine;
using System.Collections;

public class CarContinue : MonoBehaviour
{
    public StopCar Stopper;
    public DriverControl Controller;
    public ShipGrow Grow;
    public RG_IKDriver Driver;
    public bool IsTimed = false;
    private bool _fired = false;
    public float TimeStopped;
    private float _origTime;

    // Use this for initialization
    void Start ()
    {
        _origTime = TimeStopped;
    }
	
	// Update is called once per frame
	void Update () {
	    if (IsTimed && !_fired)
	    {
	        TimeStopped -= Time.deltaTime;
	        if (TimeStopped < 0)
	        {
	            Stopper.Continue = true;
	            Controller.SolvedScenario = false;
	            Driver.FootPosition = RG_IKDriver.FootState.Gas;
	            _fired = true;
	        }
	    }
	}

    public void Restart()
    {
        if (IsTimed)
        {
            TimeStopped = _origTime;
            _fired = false;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (!IsTimed && col.gameObject.tag == "car")
        {
            Stopper.Continue = true;
            Controller.SolvedScenario = false;
            Driver.FootPosition = RG_IKDriver.FootState.Gas;
            if (Grow != null)
            {
                Grow.Grow = false;
                Grow.ScaleTo = 0;
                Grow.Activate = true;
            }
        }
    }
}
