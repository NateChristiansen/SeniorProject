using UnityEngine;
using System.Collections;

public class PillarRotate : MonoBehaviour {

	public float RotationDegreesPerSecond = 45;
	public static bool _rotate = false;
	public GameObject pillar;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(_rotate == true)
			pillar.transform.Rotate(0, RotationDegreesPerSecond*Time.deltaTime, 0);
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "groundtrigger")
		{
			_rotate = false;
		}

		if (col.gameObject.tag == "car")
		{
			_rotate = true;
		}
	}

}
