using System;
using UnityEngine;
using System.Collections;

public class Recenter : MonoBehaviour {

	// Use this for initialization

    ClickManager cm = new ClickManager();
    public GvrViewer gvr;
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        // PC/Mac
        if (Input.GetMouseButtonDown(0))
        {
            if (cm.DoubleClick())
	        {
                gvr.Recenter();
	        }
        }
        // Mobile
        else if (Input.touchCount > 0)
        {
            foreach (var touch in Input.touches)
            {
                if (touch.tapCount == 2)
                {
                    gvr.Recenter();
                }
            }
        }

	}
}
