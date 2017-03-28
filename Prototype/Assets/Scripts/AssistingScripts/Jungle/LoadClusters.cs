using UnityEngine;
using System.Collections;

public class LoadClusters : MonoBehaviour {

	public GameObject Cluster;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider col)
	{
		Cluster.SetActive(true);
	}

	
}
