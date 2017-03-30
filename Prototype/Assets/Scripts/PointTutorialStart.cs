using UnityEngine;
using System.Collections;

public class PointTutorialStart : MonoBehaviour {
    public Transform Point1, Point2;
    private float _carLoc;
    public MoveCar Car;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

    }

    void OnTriggerEnter(Collider col)
    {
        _carLoc = Car.m_t;
        Point1.gameObject.SetActive(true);
        Point2.gameObject.SetActive(true);
    }

    public void Restart()
    {
        Point1.gameObject.SetActive(true);
        Point1.gameObject.GetComponent<Renderer>().enabled = true;
        Point2.gameObject.SetActive(true);
        Point2.gameObject.GetComponent<Renderer>().enabled = true;
        Car.m_t = _carLoc;
    }
}
