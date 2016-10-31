using UnityEngine;
using System.Collections;

public class StartScenario : MonoBehaviour {

    GameObject vehicle;
    bool playerAction = false;
    
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKey(KeyCode.RightArrow)) playerAction = true;
    }
}
