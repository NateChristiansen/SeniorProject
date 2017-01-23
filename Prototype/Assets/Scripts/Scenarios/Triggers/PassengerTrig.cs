﻿using UnityEngine;
using System.Collections;

public class PassengerTrig : AbstractScenarioTrigger
{

    private bool _isTriggered;
    void OnCollisionExit(Collision col)
    {
        if (_isTriggered) return;

        var stop = gameObject.AddComponent<PassengerScenario>();
        stop.GoodChoiceText = GoodChoiceText;
        stop.BadChoiceText = BadChoiceText;
        stop.DefaultChoiceText = DefaultChoiceText;
        stop.Timer = Time;
        stop.SlowTimeScale = .2f;
        _isTriggered = true;
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
