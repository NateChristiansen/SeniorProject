using UnityEngine;
using System.Collections;

public class TutorialHitCar : MonoBehaviour
{
    public TutorialPoint[] Points;
    public TutorialScenarioStart StartPoint;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "car")
        {
            foreach (TutorialPoint p in Points)
            {
                p.gameObject.SetActive(true);
                p.gameObject.GetComponent<Renderer>().enabled = true;
            }
            StartPoint.Restart();
        }
    }
}
