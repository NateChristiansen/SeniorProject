using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ContButton : MonoBehaviour, IGvrGazeResponder
{

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    private void LoadSpace()
    {
        SceneManager.LoadScene("spaceScene");
    }

    private void LoadLava()
    {
        SceneManager.LoadScene("lavaScene");
    }

    public void OnGazeEnter()
    {

    }

    public void OnGazeExit()
    {
        
    }

    public void OnGazeTrigger()
    {
        if (TransController.CompletedLevel.Equals("jungleScene"))
        {
            LoadLava();
        }
        else if (TransController.CompletedLevel.Equals("lavaScene"))
        {
            LoadSpace();
        }
    }
}
