using System;
using UnityEngine;
using System.Collections;
using Battlehub.SplineEditor;

public class MoveCar : MonoBehaviour
{

    public Spline Path;
    public float Speed;
    private float t;
    public bool Loop;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        t += Speed * Time.deltaTime;
        if (t > 1f && Loop) t = 0;
        var point = Path.GetPoint(t);
        var direction = Path.GetDirection(t);
        gameObject.transform.position = point;
        gameObject.transform.rotation = Quaternion.LookRotation(direction);
    }
}