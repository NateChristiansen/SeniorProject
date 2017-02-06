using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;

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
        if (SetStart) return; // need to stop this from triggering if the game is ready to start

        if (col.gameObject.name == "endpos")
            transform.position = GameObject.Find("startpos").transform.position;
    }

    public void DriveIntoExit()
    {

        Transform tunnelBlock = GameObject.Find("FrontTunnelBlock").gameObject.transform; // location of darkness to drive into
        float step = Speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(tunnelBlock.position.x + 150f, 0f, tunnelBlock.position.z), step); // car moves towards it
    }
}
