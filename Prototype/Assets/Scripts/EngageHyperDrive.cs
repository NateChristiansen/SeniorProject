using UnityEngine;
using System.Collections;

public class EngageHyperDrive : MonoBehaviour
{
    public ParticleSystem Particles;
    public Transform ObjectToDestroy;
    public float TimeToWait;
    public bool Activate = false;
    public MoveCar Driver;
    private float _speed;
    private bool _activated = false;
	// Use this for initialization
	void Start () {
	
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
	            while (Particles.isPlaying){}
	            Driver.Speed = _speed;
	        }
	    }
	}

    void OnTriggerEnter(Collider col)
    {
        if (!_activated)
        {
            _speed = Driver.Speed;
            Activate = true;
            Driver.Speed = 0;
            Particles.Play();
            if (ObjectToDestroy != null)
                Destroy(ObjectToDestroy.gameObject);
            _activated = true;
        }
    }
}
