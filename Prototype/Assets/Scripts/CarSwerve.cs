using UnityEngine;
using System.Collections;
using Battlehub.SplineEditor;

public class CarSwerve : MonoBehaviour
{
    public Spline OriginalPath, BranchingPath;
    public MoveCar CarPath;
    public RG_IKDriver Driver;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider col)
    {
        if (Driver.LookTarget == RG_IKDriver.LookState.Straight)
        {
            CarPath.Path = BranchingPath;
        }
    }
}
