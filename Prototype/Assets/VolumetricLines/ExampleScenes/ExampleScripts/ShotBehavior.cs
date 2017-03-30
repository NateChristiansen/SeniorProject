using UnityEngine;
using System.Collections;

public class ShotBehavior : MonoBehaviour
{
    public int Mult = 1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += transform.forward * Time.deltaTime * 1000f * Mult;
	}
}
