using UnityEngine;
using System.Collections;

public class PointObject : MonoBehaviour, IGvrGazeResponder
{
    public int PointValue;
    private bool _triggered;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnGazeEnter()
    {
        if (!_triggered)
            GlobalValues.Score += PointValue;
        _triggered = true;
    }

    public void OnGazeExit()
    {
        Destroy(gameObject);
    }

    public void OnGazeTrigger()
    {
    }
}
