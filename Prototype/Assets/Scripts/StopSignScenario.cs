using System;
using UnityEngine;
using System.Collections;

public class StopSignScenario : MonoBehaviour
{

    public float Timer = 5f; // initial countdown timer
    public string GoodChoiceText;
    public string BadChoiceText;
    public string DefaultChoiceText;
    private TextMesh _textMesh; // gui countdown mesh (user sees this)

    // various flags
    private static bool _scenarioEnded;
    private static bool _selectionMade;
    private static string _selectionResult;

    // Use this for initialization
	void Start ()
	{
        InitializeScript();
	}

    // initialize the scenario
    void InitializeScript()
    {
        // init the defaults
        this.enabled = true;
        _scenarioEnded = false;
        _selectionMade = false;
        _selectionResult = "default";

        // slow time
        SlowTime();

        //Set menu to active
        SetMenuActive();

        // Set Menu Text
        if (!string.IsNullOrEmpty(GoodChoiceText) || !string.IsNullOrEmpty(BadChoiceText) || !string.IsNullOrEmpty(DefaultChoiceText))
            SetMenuText();

        // count down on GUI
        _textMesh = GameObject.Find("TimerText").GetComponent<TextMesh>();

        // set initial count down value
        _textMesh.text = Timer.ToString();

        Debug.Log("init complete");
    }

    // set whether the user has selected or not
    public void SetSelectionMade(bool input)
    {
        _selectionMade = input;
    }

    // set what the selection was
    public void SetSelectionResult(string result)
    {
        _selectionResult = result;
    }

    // slow down the time (needs adjustment)
    void SlowTime()
    {
        // slow down time (besides character)
        Time.timeScale = (float).3;
    }

    void SetMenuText()
    {
        GameObject.Find("GoodSelectionText").GetComponent<TextMesh>().text = GoodChoiceText;
        GameObject.Find("BadSelectionText").GetComponent<TextMesh>().text = BadChoiceText;
        GameObject.Find("DefaultSelectionText").GetComponent<TextMesh>().text = DefaultChoiceText;
    }

    // time is set back to the original
    void ResumeTime()
    {
        Time.timeScale = 1;
    }

    // scenario menu activates
    void SetMenuActive()
    {
        foreach (Transform child in GameObject.Find("ScenarioMenu").transform)
        {
            child.gameObject.SetActive(true);
        }
    }

    // scenario menu is set inactive
    void SetMenuInactive()
    {
        foreach (Transform child in GameObject.Find("ScenarioMenu").transform)
        {
            child.gameObject.SetActive(false);
        }
    }

    // time is continually updated to count down to 0
    void UpdateTimer()
    {
        Timer -= Time.deltaTime / Time.timeScale;
        if (Timer > 0)
        {
            _textMesh.text = Timer.ToString();
        }
        else
        {
            SetMenuInactive();
        }
    }

    // produce the outcome of the scenario
    public void EndScenario()
    {
        // deactivate the menu
        SetMenuInactive();

        // Resume time
        ResumeTime();

        switch (_selectionResult)
        {
            case "good":
                GoodResult();
                break;
            case "bad":
                BadResult();
                break;
            case"default":
                DefaultResult();
                break;
        }
    }

    // the result of a good choice
    public void GoodResult()
    {
        Debug.Log("GOOD MADE");

        

        this.enabled = false;
    }

    // the result of a bad choice
    public void BadResult()
    {
        Debug.Log("BAD MADE");
        this.enabled = false;
    }

    // the rersult of a default choice
    public void DefaultResult()
    {
        Debug.Log("DEFAULT MADE");
        this.enabled = false;
    }

	// Update is called once per frame
	void Update ()
	{
        // continually update the timer
        UpdateTimer();

        // if user makes a choice..
	    if (Timer <= 0)
	    {
            if (_selectionMade)
            {
                // the scenario ends
                _scenarioEnded = true;

                // Produce the result
                EndScenario();
            }
            else if (Timer <= 0f && !_selectionMade)
            {
                _scenarioEnded = true;
                _selectionResult = "default";
                EndScenario();
            }
	    }

	}

    
}
