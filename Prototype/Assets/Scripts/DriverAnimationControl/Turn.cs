﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Turn : MonoBehaviour
{
    public enum TurnState
    {
        BigLeft = -2,
        Left = -1,
        Straight = 0,
        Right = 1,
        BigRight = 2
    }

    public TurnState TurnType;

    private RG_IKDriver _driver;
    // Use this for initialization
    void Start()
    {
        _driver = GameObject.Find("MCSMaleLite").GetComponent<RG_IKDriver>();
    }

    // Update is called once per frame
    void Update () {
	
	}
    
    void OnTriggerEnter(Collider obj)
    {
        if (obj.gameObject.name == "car_body")
        {
            _driver.HorizontalInput = (int) TurnType;
        }
    }
}