using UnityEngine;
using System.Collections;

public class MoveCar : MonoBehaviour {

<<<<<<< HEAD
    public BezierCurve path;
=======
    public BezierPath path;
>>>>>>> 84ad8a2f0574c8f4902090857981526688a4350f
    public float speed;
    private float t = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        t += speed * Time.deltaTime;
<<<<<<< HEAD
	    if (t > 100) t = 0;
        transform.LookAt(path.GetPointAt(t));
	    transform.position = path.GetPointAt(t);
=======
        transform.position = path.GetPositionByT(t);
>>>>>>> 84ad8a2f0574c8f4902090857981526688a4350f
    }
}
