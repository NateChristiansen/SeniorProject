using UnityEngine;
using System.Collections;
using System.Reflection.Emit;

public class EngageHyperDrive : MonoBehaviour
{
    public ParticleSystem Particles;
    public Transform ObjectToDestroy;
    public float TimeToWait;
    [HideInInspector]
    public bool Activate = false;
    public MoveCar Driver;
    private float _speed;
    private bool _activated = false;
    private float timetostart;
	// Use this for initialization
	void Start ()
    {
        _speed = Driver.Speed;
    }
	
	// Update is called once per frame
	void Update () {
	    if (Activate)
	    {
	        if (TimeToWait > 0)
	        {
	            TimeToWait -= Time.deltaTime;
	        }
	        else
	        {
	            Activate = false;
                Particles.Stop();
	            timetostart = 2;
	        }
        }
	    if (timetostart > 0)
	    {
	        timetostart -= Time.deltaTime;
            if (timetostart < 0)
	            Driver.Speed = _speed;
	    }
	}

    void OnTriggerEnter(Collider col)
    {
        if (!_activated)
        {
            Activate = true;
            Driver.Speed = 0;
            Particles.Play();
            if (ObjectToDestroy != null)
                Destroy(ObjectToDestroy.gameObject);
            _activated = true;
        }
    }
}
