using UnityEngine;
using System.Collections;

public class CarContinue : MonoBehaviour
{
    public StopCar Stopper;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider col)
    {
        Stopper.Continue = true;
    }
}
