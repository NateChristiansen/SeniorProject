using UnityEngine;
using System.Collections;

public class TimedObject : MonoBehaviour
{
    public float TimeAlive = 1;
    public bool IsStarted;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (IsStarted)
	    {
	        if (TimeAlive > 0)
	        {
	            TimeAlive -= Time.deltaTime;
	        }
	        else
	        {
	            Destroy(gameObject);
	        }
	    }
	}
}
