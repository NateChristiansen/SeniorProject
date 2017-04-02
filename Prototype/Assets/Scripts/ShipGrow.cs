using UnityEngine;
using System.Collections;

public class ShipGrow : MonoBehaviour {
    public bool Activate;
    public Transform Rocket;
    public float ScaleTo;
    public bool Grow = true;

    public float Rate = 5;
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
	            Rocket.localScale += new Vector3(t*Rate, t*Rate, t*Rate);
	        }
	        else if (!Grow && Rocket.localScale.x > ScaleTo)
	        {
                Rocket.localScale = new Vector3(Rocket.localScale.x + t * -1 * Rate, Rocket.localScale.y + t *-1 * Rate, Rocket.localScale.z + t *-1 * Rate);
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
