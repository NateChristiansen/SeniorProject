using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class FinalTransController : MonoBehaviour 
{

    public TextMesh JungleOrbs;
    public TextMesh JungleScenarios;

    public TextMesh LavaOrbs;
    public TextMesh LavaScenarios;

    public TextMesh SpaceOrbs;
    public TextMesh SpaceScenarios;

    public TextMesh OverallOrbs;
    public TextMesh OverallScenarios;

	// Use this for initialization
	void Start () 
    {

	    LoadJungleData();
        LoadLavaData();
        LoadSpaceData();
        LoadOverallData();
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    private void LoadJungleData()
    {

        JungleOrbs.text = "Orbs: " + GlobalValues.GetInstance().GetJungleOrbsCollected() + " / " +
                       GlobalValues.GetInstance().JungleOrbAmount;


        JungleScenarios.text = "Scenarios: " + GlobalValues.GetInstance().GetJungleScenariosCompleted() + " / " +
                            GlobalValues.GetInstance().JungleScenarioAmount;
    }

    private void LoadLavaData()
    {
        LavaOrbs.text = "Orbs: " + GlobalValues.GetInstance().GetLavaOrbsCollected() + " / " +
                       GlobalValues.GetInstance().LavaOrbAmount;


        LavaScenarios.text = "Scenarios: " + GlobalValues.GetInstance().GetLavaScenariosCompleted() + " / " +
                            GlobalValues.GetInstance().LavaScenarioAmount;

    }

    private void LoadSpaceData()
    {
        SpaceOrbs.text = "Orbs: " + GlobalValues.GetInstance().GetSpaceOrbsCollected() + " / " +
                       GlobalValues.GetInstance().SpaceOrbAmount;


        SpaceScenarios.text = "Scenarios: " + GlobalValues.GetInstance().GetSpaceScenariosCompleted() + " / " +
                            GlobalValues.GetInstance().SpaceScenarioAmount;
    }

    private void LoadOverallData()
    {
        OverallOrbs.text = "Orbs: " + GlobalValues.GetInstance().GetTotalOrbsCollected() + " / " +
               GlobalValues.GetInstance().GetTotalOrbsAvailable();


        OverallScenarios.text = "Scenarios: " + GlobalValues.GetInstance().GetTotalCompletedScenarios() + " / " +
                            GlobalValues.GetInstance().GetTotalScenariosAvailable();
    }


}
