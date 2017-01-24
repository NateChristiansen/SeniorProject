﻿using UnityEngine;
using System.Collections;

public class StopSignTrig : ScenarioTrigger 
{
    private bool _isTriggered;
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "car_body")
        {
            if (_isTriggered) return;
            var stop = gameObject.AddComponent<StopSignScenario>();
            stop.GoodChoiceText = GoodChoiceText;
            stop.BadChoiceText = BadChoiceText;
            stop.DefaultChoiceText = DefaultChoiceText;
            stop.Timer = Time;
            stop.SlowTimeScale = .2f;
            _isTriggered = true;
        }
    }

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
