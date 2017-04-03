using System;
using UnityEngine;
using System.Collections;

public class ShotBehavior : MonoBehaviour
{
    public int Mult = 1;
    private int _ufoct = 0;
    public UFOHealth UFO;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += transform.forward * Time.deltaTime * 700f * Mult;
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "ufo")
        {
            _ufoct++;
            if (_ufoct == 2)
            {
                UFO.Health--;
                if (UFO.Health <= 0) UFO.Activate();
            }
        }
        if (col.gameObject.tag == "car" || col.gameObject.tag == "ufo")
        {
            gameObject.GetComponent<AudioSource>().Play();
        }
    }
}
