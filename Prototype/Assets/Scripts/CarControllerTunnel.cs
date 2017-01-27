using UnityEngine;
using System.Collections;

public class CarControllerTunnel : MonoBehaviour {

    public float Speed;

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	    float step = Speed*Time.deltaTime;
	    transform.position = Vector3.MoveTowards(transform.position, GameObject.Find("endpos").transform.position, step);
	}

    void OnTriggerEnter(Collider col)
    {
        transform.position = GameObject.Find("startpos").transform.position;
    }
}
