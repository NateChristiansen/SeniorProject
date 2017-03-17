using UnityEngine;
using System.Collections;

public class StartUp : MonoBehaviour
{
    public GameObject RockParentObject;
    public GameObject RockParentObject2;
	// Use this for initialization
	void Start () 
    {
	    MakeRocksInvisible();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void MakeRocksInvisible()
    {
        foreach (Transform child in RockParentObject.transform)
        {
            child.gameObject.SetActive(false);
        }
        foreach (Transform child in RockParentObject2.transform)
        {
            child.gameObject.SetActive(false);
        }
    }
}
