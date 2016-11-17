using System;
using UnityEngine;
using System.Collections;

public class MoveCar : MonoBehaviour
{

    public BezierCurve Path;
    public float Speed;
    private float t = (float) .07;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        t += Speed * Time.deltaTime;
        if (t >= .965)
            t = (float) 0.07;
        transform.LookAt(Path.GetPointAt(t));
        transform.position = Path.GetPointAt(t);
    }
}