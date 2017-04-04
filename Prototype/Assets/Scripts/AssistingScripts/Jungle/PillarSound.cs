using UnityEngine;
using System.Collections;

public class PillarSound : MonoBehaviour {

	public AudioSource carSound;
	public AudioSource hitSound;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter(Collision col)
	{

		if (col.gameObject.tag.Equals("car"))
		{
			carSound.Play();
		}


	}

	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag.Equals ("groundtrigger"))
		{
			PillarRotate._rotate = false;
			hitSound.Play();
		}
	}
}
