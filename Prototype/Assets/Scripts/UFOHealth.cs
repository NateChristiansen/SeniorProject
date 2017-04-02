using UnityEngine;
using System.Collections;

public class UFOHealth : MonoBehaviour
{
    public Transform Smoke;

    public int Health;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

    public void Activate()
    {
        Smoke.gameObject.SetActive(true);
    }
}
