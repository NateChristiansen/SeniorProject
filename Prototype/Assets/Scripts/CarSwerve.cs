using UnityEngine;
using System.Collections;
using Battlehub.SplineEditor;

public class CarSwerve : MonoBehaviour
{
    public MoveCar CarPath;
    public RG_IKDriver Driver;
    public RG_IKDriver.LookState Direction;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "car")
        {
            if (Driver.LookTarget == Direction)
            {
                CarPath.LookingStraight = true;
            }
            else
                CarPath.LookingStraight = false;
        }
    }
}
