using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

public class AnimatePassengerDoor : MonoBehaviour, IGvrGazeResponder
{

    public GameObject doorHandle;
    public GameObject doorWindow;
    private bool down = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        doorHandle.GetComponent<Animation>().wrapMode = WrapMode.Once;
        doorWindow.GetComponent<Animation>().wrapMode = WrapMode.Once;
	}

    public void OnGazeEnter()
    {

    }

    public void OnGazeExit()
    {
        
    }

    public void OnGazeTrigger()
    {
        var handle = doorHandle.GetComponent<Animation>();
        var window = doorWindow.GetComponent<Animation>();
        if (!down)
        {
            handle["R_door_handle_2"].speed = 1;
            handle.Play();
            window["R_window_down"].speed = 1;
            window.Play();
        }
        else
        {
            if (handle["R_door_handle_2"].time.Equals(0))
                handle["R_door_handle_2"].time = handle["R_door_handle_2"].length;
            handle["R_door_handle_2"].speed = -1;
            handle.Play();
            if (window["R_window_down"].time.Equals(0))
                window["R_window_down"].time = window["R_window_down"].length;
            window["R_window_down"].speed = -1;
            window.Play();
        }
        down = !down;
    }
}
