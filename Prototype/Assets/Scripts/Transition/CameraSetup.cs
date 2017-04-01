using UnityEngine;
using System.Collections;

public class CameraSetup : MonoBehaviour
{
    public GameObject ScoreBoard;
	// Use this for initialization
	void Start () 
    {
        Debug.Log("Works");
	    this.transform.LookAt(ScoreBoard.transform.position);
	}
	
	// Update is called once per frame
	void Update () 
    {

	}
}
