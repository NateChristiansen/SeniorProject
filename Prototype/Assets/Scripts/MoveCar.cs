using UnityEngine;
using System.Collections;

public class MoveCar : MonoBehaviour {

    public BezierPath path;
    public float speed;
    private float t = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        t += speed * Time.deltaTime;
        transform.position = path.GetPositionByT(t);
    }
}
