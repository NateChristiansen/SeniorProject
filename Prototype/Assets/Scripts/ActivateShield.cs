using UnityEngine;
using System.Collections;

public class ActivateShield : MonoBehaviour
{
    public GameObject Shield;

    public RG_IKDriver Driver;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "car" && Driver.LookTarget == RG_IKDriver.LookState.Straight)
        {
            Shield.SetActive(false);
            Shield.SetActive(true);
        }
    }
}
