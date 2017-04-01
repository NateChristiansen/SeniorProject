using UnityEngine;
using System.Collections;

public class RockSpeed : MonoBehaviour {

	public GameObject go;
	public float speed;

	// Use this for initialization
	void Start () {
		Rigidbody rg = go.GetComponent<Rigidbody>();
		rg.velocity = new Vector3 (0, speed, 0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
