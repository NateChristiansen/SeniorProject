using UnityEngine;
using System.Collections;

public class Menu_Quit : MonoBehaviour, IGvrGazeResponder {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnGazeEnter()
    {
        
    }

    public void OnGazeExit()
    {
        
    }

    public void OnGazeTrigger()
    {
        Debug.Log("Application exited in startMenu");
        Application.Quit();
    }
}
