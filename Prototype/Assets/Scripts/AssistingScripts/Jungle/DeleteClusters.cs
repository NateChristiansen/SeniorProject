using UnityEngine;
using System.Collections;

public class DeleteClusters : MonoBehaviour {


	public GameObject Cluster;
	// Use this for initialization
	void Start () 
	{

	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider col)
	{
        if (col.gameObject.tag == "car")
		    Destroy (Cluster);
	}
}
