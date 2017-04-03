using UnityEngine;
using System.Collections;

public class DeactivateShield : MonoBehaviour
{
    public GameObject Shield;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "car")
            Shield.SetActive(false);
    }
}
