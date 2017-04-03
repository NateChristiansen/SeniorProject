using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalValues : MonoBehaviour
{
    // Total orbs possible
    public int JungleOrbAmount;
    public int LavaOrbAmount;
    public int SpaceOrbAmount;

    // Total scenarios possible
    public int JungleScenarioAmount;
    public int LavaScenarioAmount;
    public int SpaceScenarioAmount;

    // Orbs user collected
    private int _jungleOrbsCollected;
    private int _lavaOrbsCollected;
    private int _spaceOrbsCollected;

    // Scenarios user completed
    private int _jungleScenariosCompleted;
    private int _lavaScenariosCompleted;
    private int _spaceScenariosCompleted;

    private static GlobalValues _instance = null;

    public static GlobalValues GetInstance()
    {
        if (_instance == null)
            _instance = FindObjectOfType(typeof(GlobalValues)) as GlobalValues;

        if (_instance == null)
        {
            GameObject myObj = new GameObject("GlobalValues");
            _instance = myObj.AddComponent(typeof(GlobalValues)) as GlobalValues;
            Debug.Log("Could not locate GlobalValues object. One has been automatically generated.");
        }

        return _instance;
    }

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    void OnApplicationQuit()
    {
        _instance = null;
    }

	// Use this for initialization
	void Start ()
	{
	    GetInstance();
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    /// <summary>
    /// Add an orb when the user collects one
    /// </summary>
    public void AddToOrbTotal()
    {
        string activeScene = SceneManager.GetActiveScene().name;

        if (activeScene.Equals("jungleScene"))
        {
            _jungleOrbsCollected++;
        }
        else if (activeScene.Equals("lavaScene"))
        {
            _lavaOrbsCollected++;
        }
        else if (activeScene.Equals("spaceScene"))
        {
            _spaceOrbsCollected++;
        }
    }

    /// <summary>
    /// Add a scenario completion to user score
    /// </summary>
    public void AddToScenarioCompletionTotal()
    {
        string activeScene = SceneManager.GetActiveScene().name;

        if (activeScene.Equals("jungleScene"))
        {
            _jungleScenariosCompleted++;
        }
        else if (activeScene.Equals("lavaScene"))
        {
            _lavaScenariosCompleted++;
        }
        else if (activeScene.Equals("spaceScene"))
        {
            _spaceScenariosCompleted++;
        }
    }

    /// <summary>
    /// Get the total available orbs in the game
    /// </summary>
    /// <returns></returns>
    public int GetTotalOrbsAvailable()
    {
        return JungleOrbAmount + LavaOrbAmount + SpaceOrbAmount;
    }

    /// <summary>
    /// Get the total orbs the user collected
    /// </summary>
    /// <returns></returns>
    public int GetTotalOrbsCollected()
    {
        return _jungleOrbsCollected + _lavaOrbsCollected + _spaceOrbsCollected;
    }

    /// <summary>
    /// Return the total amount of scenarios in the game
    /// </summary>
    /// <returns></returns>
    public int GetTotalScenariosAvailable()
    {
        return JungleScenarioAmount + LavaScenarioAmount + SpaceScenarioAmount;
    }

    /// <summary>
    /// Total amount of scenarios the user successfully completed
    /// </summary>
    /// <returns></returns>
    public int GetTotalCompletedScenarios()
    {
        return _jungleScenariosCompleted + _lavaScenariosCompleted + _spaceScenariosCompleted;
    }

    /////////////// ORBS THE USER HAS COLLECTED FOR EACH LEVEL///////////////
    public int GetJungleOrbsCollected()
    {
        return _jungleOrbsCollected;
    }

    public int GetLavaOrbsCollected()
    {
        return _lavaOrbsCollected;
    }

    public int GetSpaceOrbsCollected()
    {
        return _spaceOrbsCollected;
    }
    ///////////////////////////////////////////////////////

    public int GetJungleScenariosCompleted()
    {
        return _jungleScenariosCompleted;
    }

    public int GetLavaScenariosCompleted()
    {
        return _lavaScenariosCompleted;
    }

    public int GetSpaceScenariosCompleted()
    {
        return _spaceScenariosCompleted;
    }

    public void DisplayData()
    {
        string activeScene = SceneManager.GetActiveScene().name;

        if (activeScene.Equals("jungleScene"))
        {
            Debug.Log("Scene: " + activeScene);
            Debug.Log("Orbs: " + _jungleOrbsCollected + " / " + JungleOrbAmount);
            Debug.Log("Scenarios: " + _jungleScenariosCompleted + " / " + JungleScenarioAmount);
        }
        else if (activeScene.Equals("lavaScene"))
        {
            Debug.Log("Scene: " + activeScene);
            Debug.Log("Orbs: " + _lavaOrbsCollected + " / " + LavaOrbAmount);
            Debug.Log("Scenarios: " + _lavaScenariosCompleted + " / " + LavaScenarioAmount);
        }
        else if (activeScene.Equals("spaceScene"))
        {
            Debug.Log("Scene: " + activeScene);
            Debug.Log("Orbs: " + _spaceOrbsCollected + " / " + SpaceOrbAmount);
            Debug.Log("Scenarios: " + _spaceScenariosCompleted + " / " + SpaceScenarioAmount);
        }
    }
}
