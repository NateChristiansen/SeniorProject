using UnityEngine;
using System.Collections;

public class TutorialScenarioEnd : MonoBehaviour {

    public MoveCar Car;
    public PointTutorialStart StartPoint;
    public CheckLook Checker;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider col)
    {
        if (!Checker.Pass)
        {
            StartPoint.Restart();
        }
    }
}
