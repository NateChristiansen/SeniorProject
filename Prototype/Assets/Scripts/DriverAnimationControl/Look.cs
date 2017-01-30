using System;
using UnityEngine;
using System.Collections;

public class Look : MonoBehaviour
{
    public enum LookState
    {
        Down = -1,
        Straight = 0,
        Up = 1
    }
    private RG_IKDriver _driver;
    public LookState LookType;
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
            _driver.LookTarget = (float)LookType / 2;
        }
    }
}
