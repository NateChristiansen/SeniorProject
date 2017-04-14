using UnityEngine;
using System.Collections;

public class ReflectShot : MonoBehaviour
{
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "shot")
        {
            col.gameObject.GetComponent<ShotBehavior>().Mult = -1;
        }
    }
}
