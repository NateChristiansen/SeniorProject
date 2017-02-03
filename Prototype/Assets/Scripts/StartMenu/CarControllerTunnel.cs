using UnityEngine;
using System.Collections;

public class CarControllerTunnel : MonoBehaviour {

    public float Speed;

    public bool SetStart;
	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
        if (!SetStart)
        {
            float step = Speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, GameObject.Find("endpos").transform.position, step); 
	    }
        else
        {
            DriveIntoExit();
        }
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "endpos")
            transform.position = GameObject.Find("startpos").transform.position;
    }

    public void DriveIntoExit()
    {
        float step = Speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(793f, 0f, 5000), step);
    }
}
