using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StraightenTurn : MonoBehaviour
{
    private RG_IKDriver _driver;
    // Use this for initialization
    void Start()
    {
        _driver = GameObject.Find("MCSMaleLite").GetComponent<RG_IKDriver>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider obj)
    {
        if (obj.gameObject.name == "car_body")
        {
            _driver.HorizontalInput = 0;
        }
    }
}
