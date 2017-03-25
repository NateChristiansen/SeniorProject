using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Turn : MonoBehaviour
{
    public RG_IKDriver.TurnState TurnType;

    private RG_IKDriver _driver;
    // Use this for initialization
    void Start()
    {
        _driver = GameObject.Find("MCSMaleLite").GetComponent<RG_IKDriver>();
    }

    // Update is called once per frame
    void Update () {
	
	}
    
    void OnTriggerEnter(Collider obj)
    {
        if (obj.gameObject.tag == "car")
        {
            _driver.TurnType = TurnType;
        }
    }
}
