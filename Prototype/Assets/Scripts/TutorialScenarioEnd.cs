using UnityEngine;
using System.Collections;

public class TutorialScenarioEnd : MonoBehaviour {

    public MoveCar Car;
    public TutorialScenarioStart StartPoint;
    public CheckLook Checker;
    public StopCar CarStopper;
    public TutorialText Ending;
    private bool _lock;

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
            CarStopper.Restart();
            StartPoint.Restart();
        }
        else if (Checker.Pass && Ending != null && !_lock)
        {
            _lock = true;
            Ending.gameObject.SetActive(true);
        }
    }
}
