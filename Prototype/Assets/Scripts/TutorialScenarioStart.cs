using UnityEngine;
using System.Collections;

public class TutorialScenarioStart : MonoBehaviour
{

    private float _carLoc;
    public MoveCar Car;

    public TutorialText Tutorial;

    // Use this for initialization
    void Start()
    {

    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "car")
            _carLoc = Car.m_t;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Restart()
    {
        Car.m_t = _carLoc;
        Tutorial.gameObject.SetActive(true);
    }
}