using UnityEngine;
using System.Collections;

public class GlobalValues : MonoBehaviour
{
    public static int Score = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    /// <summary>
    /// Give the user 50 points for collecting a point object
    /// </summary>
    public static void CollectedPoint()
    {
        Score += 50;
    }

    /// <summary>
    /// Give the user 500 points for a successful scenario
    /// </summary>
    public static void ScenarioCompletion()
    {
        Score += 500;
    }
}
