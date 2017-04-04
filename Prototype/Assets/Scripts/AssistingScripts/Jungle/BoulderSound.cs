﻿using UnityEngine;
using System.Collections;

public class BoulderSound : MonoBehaviour {
	
	public AudioSource terrainSound;
	public AudioSource carSound;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter(Collision col)
	{

		if (col.gameObject.tag.Equals("car"))
		{
			terrainSound.Play();
			carSound.Play();
		}
	}

}
