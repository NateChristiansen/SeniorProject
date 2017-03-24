using UnityEngine;
using System.Collections;

public class StopSound : MonoBehaviour {

	public AudioSource Source;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider col)
	{
		Source.Stop();
	}
}
