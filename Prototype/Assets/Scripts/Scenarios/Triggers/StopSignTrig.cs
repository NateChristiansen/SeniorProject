﻿using UnityEngine;
using System.Collections;

public class StopSignTrig : MonoBehaviour 
{

    public string GoodChoiceText;
    public string BadChoiceText;
    public string DefaultChoiceText;
    public float Time;

    void OnCollisionExit(Collision col)
    {
        var stop = gameObject.AddComponent<StopSignScenario>();
        stop.GoodChoiceText = GoodChoiceText;
        stop.BadChoiceText = BadChoiceText;
        stop.DefaultChoiceText = DefaultChoiceText;
        stop.Timer = Time;
    }

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}