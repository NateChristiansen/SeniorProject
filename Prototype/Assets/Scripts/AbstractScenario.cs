using System;
using UnityEngine;
using System.Collections;

public abstract class AbstractScenario : MonoBehaviour, IScenario {

    public float Timer = 5f; // initial countdown timer
    public string GoodChoiceText;
    public string BadChoiceText;
    public string DefaultChoiceText;
    public string ScenarioIdentifier = "default";
    protected TextMesh _textMesh; // gui countdown mesh (user sees this)

    // various flags
    protected static bool _scenarioEnded;
    protected static bool _selectionMade;
    protected static string _selectionResult;

    // Use this for initialization
	protected void Start () 
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
        if (!String.IsNullOrEmpty(GoodChoiceText) || !String.IsNullOrEmpty(BadChoiceText) || !String.IsNullOrEmpty(DefaultChoiceText))
            SetMenuText();

        // count down on GUI
        _textMesh = GameObject.Find("TimerText").GetComponent<TextMesh>();

        // set initial count down value
        _textMesh.text = Timer.ToString();

        Debug.Log("init complete");
	}
	
	// Update is called once per frame
	protected void Update () 
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

    // produce the outcome of the scenario
    public abstract void GoodResult();

    public abstract void BadResult();

    public abstract void DefaultResult();

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
            case "default":
                DefaultResult();
                break;
        }

        _selectionResult = "";
    }

    void SetMenuText()
    {
        GameObject.Find("GoodSelectionText").GetComponent<TextMesh>().text = GoodChoiceText;
        GameObject.Find("BadSelectionText").GetComponent<TextMesh>().text = BadChoiceText;
        GameObject.Find("DefaultSelectionText").GetComponent<TextMesh>().text = DefaultChoiceText;
    }

    // time is continually updated to count down to 0
    protected void UpdateTimer()
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

    // slow down the time (needs adjustment)
    void SlowTime()
    {
        // slow down time (besides character)
        Time.timeScale = (float).3;
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

    // scenario menu activates
    protected void SetMenuActive()
    {
        foreach (Transform child in GameObject.Find("ScenarioMenu").transform)
        {
            child.gameObject.SetActive(true);
        }
    }

    // scenario menu is set inactive
    protected void SetMenuInactive()
    {
        foreach (Transform child in GameObject.Find("ScenarioMenu").transform)
        {
            child.gameObject.GetComponent<Renderer>().material.color = Color.white;
            child.gameObject.SetActive(false);
        }
    }

    // time is set back to the original
    protected void ResumeTime()
    {
        Time.timeScale = 1;
    }
}
