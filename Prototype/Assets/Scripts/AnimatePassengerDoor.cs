using UnityEngine;
using System.Collections;

public class AnimatePassengerDoor : MonoBehaviour, IGvrGazeResponder
{

    public GameObject doorHandle;
    public GameObject doorWindow;
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

        Debug.Log("door");

        doorHandle.GetComponent<Animation>().Play();
        doorWindow.GetComponent<Animation>().Play();
    }
}
