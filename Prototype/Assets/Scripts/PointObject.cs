using UnityEngine;
using System.Collections;

public class PointObject : MonoBehaviour, IGvrGazeResponder
{
    public int PointValue;
    private bool _triggered;
    private AudioSource _clip;
    private bool _collected;
    public float RotationDegreesPerSecond = 45;
	// Use this for initialization
	void Start ()
	{
	    _clip = gameObject.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update ()
	{
	    transform.Rotate(0, RotationDegreesPerSecond*Time.deltaTime, 0);
	    if (_collected && !_clip.isPlaying)
	    {
            Destroy(gameObject);
        }
	}

    public void OnGazeEnter()
    {
        if (!_triggered)
        {
            GlobalValues.Score += PointValue;
            _clip.Play();
        }
        gameObject.GetComponent<Renderer>().enabled = false;
        _triggered = true;
    }

    public void OnGazeExit()
    {
        _collected = true;
    }

    public void OnGazeTrigger()
    {
    }
}
