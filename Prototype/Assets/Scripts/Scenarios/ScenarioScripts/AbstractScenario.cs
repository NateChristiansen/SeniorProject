using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Random = System.Random;

public abstract class AbstractScenario : MonoBehaviour, IScenario {

    public float Timer = 5f; // initial countdown timer
    public string GoodChoiceText;
    public string BadChoiceText;
    public string DefaultChoiceText;
    public float SlowTimeScale = .25f;
    protected TextMesh _textMesh; // gui countdown mesh (user sees this)

    // various flags
    protected static bool _scenarioEnded;
    protected static bool _selectionMade;
    protected static string _selectionResult;
    protected bool _isTriggered;
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "car_body")
        {
            if (_isTriggered) return;
            enabled = true;
            Begin();
            _isTriggered = true;
        }
    }

    protected void Begin()
    {
        // slow time
        SlowTime();

        // randomize the menu
        RandomizeSelectionMenuPosition();

        //Set menu to active
        SetMenuActive();

        // Set Menu Text
        if (!String.IsNullOrEmpty(GoodChoiceText) || !String.IsNullOrEmpty(BadChoiceText) || !String.IsNullOrEmpty(DefaultChoiceText))
            SetMenuText();

        // count down on GUI
        _textMesh = GameObject.Find("TimerText").GetComponent<TextMesh>();

        // set initial count down value
        int time = (int)Timer;
        _textMesh.text = time.ToString();
    }

    // Use this for initialization
    protected void Start () 
    {
        // init the defaults
        this.enabled = false;
        _scenarioEnded = false;
        _selectionMade = false;
        _selectionResult = "default";
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

    public void DefaultResult()
    {
        Random rnd = new Random();
        int number = rnd.Next(1, 10);

        if (number%2 == 0)
        {
            GoodResult();
        }
        else
        {
            BadResult();
        }

        this.enabled = false;
    }

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

    void RandomizeSelectionMenuPosition()
    {
        // hold possible Y values of menu items
        var yPosList = new List<float>()
        {
            0, 3, 6
        };

        // random number
        Random rnd = new Random();

        int min = 0, max = 2;
        List<Transform> menuItemList = GetMenuChildren();

        for (int i = 0; i <= 2; i++)
        {
            int sel = rnd.Next(min, max);
            menuItemList[i].localPosition = new Vector3(0, yPosList[sel], 0);
            yPosList.Remove(yPosList[sel]);
            max--;
        }

    }

    List<Transform> GetMenuChildren()
    {
        return GameObject.Find("ScenarioMenu").transform.Cast<Transform>().ToList();
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
        if (Timer >= 1)
        {
            int time = (int) Timer;
            _textMesh.text = time.ToString();
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
        Time.timeScale = SlowTimeScale;
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
