using System;
using UnityEngine;
using System.Collections;

public class Look : MonoBehaviour
{

    private RG_IKDriver _driver;
    public float Amount;
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
            _driver.LookAtRoad = !(Math.Abs(Amount) > 0);
            _driver.NewTarget = Amount;
        }
    }
}
