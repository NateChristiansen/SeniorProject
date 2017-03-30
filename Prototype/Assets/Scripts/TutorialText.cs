using UnityEngine;
using System.Collections;

public class TutorialText : MonoBehaviour, IGvrGazeResponder
{
    public MoveCar Car;
    private float _initialSpeed;
	// Use this for initialization
	void Start ()
	{
	    _initialSpeed = Car.Speed;
        Car.Speed = 0;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnEnable()
    {
    }

    public void OnGazeEnter()
    {
    }

    public void OnGazeExit()
    {
    }

    public void OnGazeTrigger()
    {
        Car.Speed = _initialSpeed;
        gameObject.SetActive(false);
    }
}
