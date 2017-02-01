using UnityEngine;
using System.Collections;

public class AnimatePhone : MonoBehaviour, IGvrGazeResponder
{

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnGazeEnter()
    {
    }

    public void OnGazeExit()
    {
    }

    public void OnGazeTrigger()
    {
        var tf = gameObject.transform.localPosition;
        Vector3 newv = new Vector3(tf.x, tf.y, tf.z);
        newv.y += 1;
        gameObject.transform.localPosition = newv;
    }
}
