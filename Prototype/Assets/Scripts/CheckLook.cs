using UnityEngine;
using System.Collections;

public class CheckLook : MonoBehaviour
{
    public RG_IKDriver Driver;

    public RG_IKDriver.LookState Direction;
    [HideInInspector]
    public bool Pass;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "car")
            Pass = Driver.LookTarget == Direction;
    }
}
