﻿using UnityEngine;
using System.Collections;

public class TransController : MonoBehaviour
{
    public TextMesh TitleText;
    public TextMesh LevelText;
    public TextMesh OrbText;
    public TextMesh ScenarioText;
    public GameObject ScoreBoard;


    public static string CompletedLevel;
	// Use this for initialization
	void Start () 
    {
        Debug.Log(CompletedLevel);
	    if (CompletedLevel.Equals("jungleScene"))
	    {
	        LoadJungleData();
	    }
        else if (CompletedLevel.Equals("lavaScene"))
        {
            LoadLavaData();
        }
        else if (CompletedLevel.Equals("SpaceScene"))
        {
            LoadSpaceData();
        }
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    private void LoadJungleData()
    {

        Material tempMat = Resources.Load("JungleScore", typeof (Material)) as Material;
        ScoreBoard.gameObject.GetComponent<Renderer>().material = tempMat;

        TitleText.color = Color.white;

        LevelText.text = "Level: Jungle";
        LevelText.color = Color.white;


        OrbText.text = "Orbs: " + GlobalValues.GetInstance().GetJungleOrbsCollected() + " / " +
                       GlobalValues.GetInstance().JungleOrbAmount;
        OrbText.color = Color.white;


        ScenarioText.text = "Scenarios: " + GlobalValues.GetInstance().GetJungleScenariosCompleted() + " / " +
                            GlobalValues.GetInstance().JungleScenarioAmount;
        ScenarioText.color = Color.white;
    }

    private void LoadLavaData()
    {
        Material tempMat = Resources.Load("LavaScore", typeof(Material)) as Material;
        ScoreBoard.gameObject.GetComponent<Renderer>().material = tempMat;

        TitleText.color = Color.black;

        LevelText.text = "Level: Lava";
        LevelText.color = Color.black;


        OrbText.text = "Orbs: " + GlobalValues.GetInstance().GetLavaOrbsCollected() + " / " +
                       GlobalValues.GetInstance().LavaOrbAmount;
        OrbText.color = Color.black;


        ScenarioText.text = "Scenarios: " + GlobalValues.GetInstance().GetLavaScenariosCompleted() + " / " +
                            GlobalValues.GetInstance().LavaScenarioAmount;
        ScenarioText.color = Color.black;
    }

    private void LoadSpaceData()
    {
        Material tempMat = Resources.Load("SpaceScore", typeof(Material)) as Material;
        ScoreBoard.gameObject.GetComponent<Renderer>().material = tempMat;

        TitleText.color = Color.white;

        LevelText.text = "Level: Space";
        LevelText.color = Color.white;


        OrbText.text = "Orbs: " + GlobalValues.GetInstance().GetSpaceOrbsCollected() + " / " +
                       GlobalValues.GetInstance().SpaceOrbAmount;
        OrbText.color = Color.white;


        ScenarioText.text = "Scenarios: " + GlobalValues.GetInstance().GetSpaceScenariosCompleted() + " / " +
                            GlobalValues.GetInstance().SpaceScenarioAmount;
        ScenarioText.color = Color.white;
    }
}
