﻿using UnityEngine;
using System.Collections;
using System.Security.Cryptography;

public class PlaySound : MonoBehaviour
{
	// Use this for initialization
	void Start () 
    {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "car_body")
        {
            transform.gameObject.GetComponent<AudioSource>().Play();
        }
    }
}