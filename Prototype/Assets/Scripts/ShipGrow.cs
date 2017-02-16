using UnityEngine;
using System.Collections;
using UnityEditor;

public class ShipGrow : MonoBehaviour {
    public bool Activate;
    public Transform Rocket;
    public float ScaleTo;
    public bool Grow = true;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (Activate)
        {
            var t = Time.deltaTime;
            if (Grow && Rocket.localScale.x < ScaleTo)
	        {
	            Rocket.localScale += new Vector3(t*5, t*5, t*5);
	        }
	        else if (!Grow && Rocket.localScale.x > ScaleTo)
	        {
                Rocket.localScale = new Vector3(Rocket.localScale.x + t * -5, Rocket.localScale.y + t *-5, Rocket.localScale.z + t *-5);
	            if (Rocket.localScale.x < 0)
	            {
                    Rocket.gameObject.GetComponent<AudioSource>().Stop();
	                Destroy(Rocket.gameObject);
	            }
	        }
	        else
	        {
	            Rocket.localScale = new Vector3(ScaleTo, ScaleTo, ScaleTo);
	            Activate = false;
	        }
	    }
	}
}
