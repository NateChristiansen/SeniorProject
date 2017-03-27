﻿using UnityEngine;
using System.Collections;
using Battlehub.SplineEditor;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour
{

    public Camera MainCamera;
    public GameObject Vehicle;
    public Spline SpaceSpline;
    public int VehicleSpeed;
    public GameObject Moon;
    public GameObject SpaceTop;
    public MoveCar DriverCar;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void InitializeCar()
    {
        Debug.Log("OK");
        // set camera clipping planes to 5000
        MainCamera.farClipPlane = 5000;

        // set position to spline position
        Vehicle.transform.position = new Vector3(400, 2000, 5000);

        // set vehicle rotation
        Vehicle.transform.rotation = SpaceSpline.transform.rotation;

        // set vehicle to follow space spline
        DriverCar.Spline = SpaceSpline;

        // set speed
        DriverCar.Speed = VehicleSpeed;

        // add space objects to vehicle parent
        Moon.transform.parent = Vehicle.transform;
        SpaceTop.transform.parent = Vehicle.transform;
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag.Equals("car"))
        {
            DriverCar.Speed = 0;
            //InitializeCar();
            LoadSpace();
        }
    }

    void LoadSpace()
    {
        SceneManager.LoadScene("spaceScene");
    }
}
