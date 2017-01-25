using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StopObject : MonoBehaviour 
{

    public int StopTimeInSeconds = 3;
    public bool ChoiceIsGood = false;

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name.Equals("car_body") && ChoiceIsGood)
        {
            StopMovingObject();
        }
    }

    void StopMovingObject()
    {
        StartCoroutine(StopMovingObjectCoroutine());
    }

    IEnumerator StopMovingObjectCoroutine()
    {

        // save old speed
        float tempSpeed = GameObject.Find("Vehicle").GetComponent<MoveCar>().Speed;

        // set car to 0 speed
        GameObject.Find("Vehicle").GetComponent<MoveCar>().Speed = 0f;

        // wait at stop
        yield return new WaitForSeconds(StopTimeInSeconds);

        // resume speed
        GameObject.Find("Vehicle").GetComponent<MoveCar>().Speed = tempSpeed;
    }

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}
}
