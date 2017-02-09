using UnityEngine;
using System.Collections;

public class ShipGrow : MonoBehaviour {
    public bool Activate;
    public Transform Rocket;
    public float ScaleTo;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (Activate)
	    {
            if (Rocket.localScale.x < ScaleTo)
	            Rocket.localScale += new Vector3(Time.deltaTime * 10, Time.deltaTime * 10, Time.deltaTime * 10);
            else
                Rocket.localScale = new Vector3(ScaleTo, ScaleTo, ScaleTo);
	    }
	}
}
