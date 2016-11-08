﻿using UnityEngine;
using System.Collections;

public class TriggerScript : MonoBehaviour
{

    public GameObject player;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Collider>().tag == player.tag)
        {
            var script = gameObject.AddComponent<StartScenario>();
            script.vehicle = player;
            script.enabled = true;
        }
    }
}