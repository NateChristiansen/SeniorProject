using UnityEngine;
using System.Collections;
using System.Reflection.Emit;

public class EngageHyperDrive : MonoBehaviour
{
    public ParticleSystem Particles;
    public Transform ObjectToDestroy;
    public Transform ObjectToLoad;
    public float TimeToWait;
    [HideInInspector]
    public bool Activate = false;
    public MoveCar Driver;
    private float _speed;
    private bool _activated = false;
    private float timetostart;
    public ParticleSystem BlackHole;
    public AudioSource Engine;

    private bool _scale;
	// Use this for initialization
	void Start ()
    {
        _speed = Driver.Speed;
    }
	
	// Update is called once per frame
	void Update () {
	    if (_scale)
	    {
	        if (BlackHole != null)
	        {
	            float bh_amt = BlackHole.startSize + Time.deltaTime * 10000;
	            BlackHole.startSize = bh_amt >= 250 ? 250 : bh_amt;
	        }
	        float amt = ObjectToLoad.localScale.x + Time.deltaTime*.9f*.2f;
	        if (amt > 1)
	        {
	            _scale = false;
                ObjectToLoad.localScale = new Vector3(1, 1, 1);
	        }
            else
                ObjectToLoad.localScale = new Vector3(amt, amt, amt);
	    }
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
                if (ObjectToLoad != null) ObjectToLoad.gameObject.SetActive(true);
	            _scale = true;
	            timetostart = 2;
            }
        }
	    if (timetostart > 0)
	    {
	        timetostart -= Time.deltaTime;
	        if (timetostart <= 0)
	        {
	            Driver.Speed = _speed;
	            Engine.volume = .371f;
	        }
	    }
	}

    void OnTriggerEnter(Collider col)
    {
        if (!_activated && col.gameObject.tag == "car")
        {
            Activate = true;
            Engine.volume = 1;
            Driver.Speed = 0;
            Particles.Play();
            if (ObjectToDestroy != null)
                Destroy(ObjectToDestroy.gameObject);
            _activated = true;
        }
    }
}
