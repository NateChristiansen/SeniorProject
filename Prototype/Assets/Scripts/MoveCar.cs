using System;
using UnityEngine;
using System.Collections;

public class MoveCar : MonoBehaviour
{

    public BezierCurve path;
    public float speed;
    private float t = 0;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        t += speed * Time.deltaTime;
        if (t > 1) t = 0;
        transform.LookAt(path.GetPointAt(t));
        transform.position = path.GetPointAt(t);
    }
}