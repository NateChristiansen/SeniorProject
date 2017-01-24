﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Pedal : MonoBehaviour
{
    public enum FootState
    {
        Gas = 1, Brake = -1, Idle = 0
    }

    public FootState FootType;
    private RG_IKDriver _driver;
    // Use this for initialization
    void Start()
    {
        _driver = GameObject.Find("MCSMaleLite").GetComponent<RG_IKDriver>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider obj)
    {
        if (obj.gameObject.name == "car_body")
        {
            _driver.VerticalInput = (int) FootType;
        }
    }
}