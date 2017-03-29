using UnityEngine;
using System.Collections;

public class FireUFO : MonoBehaviour
{
    public CannonBehavior Cannon;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider col)
    {
        Cannon.Fire();
    }
}
