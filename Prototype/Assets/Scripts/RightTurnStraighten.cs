﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RightTurnStraighten : MonoBehaviour
{
    private Queue<float> _hQueue;
    // Use this for initialization
    void Start()
    {
        _hQueue = GameObject.Find("MCSMaleLite").GetComponent<RG_IKDriver>().HorizontalQueue;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider obj)
    {
        if (obj.gameObject.name == "car_body")
        {
            for (int i = 10; i >= 0; i--)
            {
                _hQueue.Enqueue(((float)i) / 10);
            }
        }
    }
}
