using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour, IGvrGazeResponder
{

    private AsyncOperation _async;
	// Use this for initialization

	void Start ()
	{
	    _async = new AsyncOperation();
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    public void OnGazeEnter()
    {
        
    }

    public void OnGazeExit()
    {
        
    }

    public void OnGazeTrigger()
    {
        if (gameObject.tag.Equals("beginExperienceSelection"))
        {
            StartGame();
        }
        else if (gameObject.tag.Equals("optionsSelection"))
        {
            Debug.Log("options");
            StopDarkness();
        }
        else if (gameObject.tag.Equals("quitSelection"))
        {
            QuitGame();
        }
    }

    private void StartGame()
    {
        SceneManager.LoadScene("protoScene");
    }

    IEnumerator Load()
    {
        _async = SceneManager.LoadSceneAsync("protoScene");
        _async.allowSceneActivation = false;
        yield return _async;
    }

    private void QuitGame()
    {
        Application.Quit();
    }

    private void StopDarkness()
    {
        
    }
}
