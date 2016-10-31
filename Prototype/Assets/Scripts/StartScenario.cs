using UnityEngine;
using System.Collections;

public class StartScenario : MonoBehaviour {

    public GameObject vehicle;
    public bool playerAction = false;
    double time = 1;
    public bool playerfail = false;
    
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            enabled = false;
        }
        time -= Time.deltaTime;
        if (time <= 0)
        {
            vehicle.GetComponent<MoveCar>().enabled = false;
            enabled = false;
        }
    }
}
