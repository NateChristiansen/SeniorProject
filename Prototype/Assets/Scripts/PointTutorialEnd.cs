using UnityEngine;
using System.Collections;

public class PointTutorialEnd : MonoBehaviour
{
    public MoveCar Car;
    public Transform Point1, Point2;
    public PointTutorialStart StartPoint;
    
	// Use this for initialization
	void Start ()
    {
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "car" && Point1.gameObject.activeSelf || Point2.gameObject.activeSelf)
        {
            StartPoint.Restart();
        }
    }
}
