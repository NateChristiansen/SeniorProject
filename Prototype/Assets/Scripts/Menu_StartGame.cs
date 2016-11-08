using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Menu_StartGame : MonoBehaviour, IGvrGazeResponder {

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
        SceneManager.LoadScene("test");
    }
}
