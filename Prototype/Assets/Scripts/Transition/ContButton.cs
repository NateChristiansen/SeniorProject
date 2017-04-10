using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ContButton : MonoBehaviour, IGvrGazeResponder
{
    public GameObject LoadScreen;
    public GameObject ScoreBoard;
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

    private void LoadStartScene()
    {
        SceneManager.LoadScene("startScene");
    }

    public void OnGazeEnter()
    {

    }

    public void OnGazeExit()
    {
        
    }

    public void OnGazeTrigger()
    {
        ScoreBoard.SetActive(false);
        LoadScreen.SetActive(true);

        if (TransController.CompletedLevel.Equals("jungleScene"))
        {
            LoadLava();
        }
        else if (TransController.CompletedLevel.Equals("lavaScene"))
        {
            LoadSpace();
        }
        else if (TransController.CompletedLevel.Equals("spaceScene"))
        {
            LoadStartScene();
        }
    }
}
