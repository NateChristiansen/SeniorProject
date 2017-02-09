using UnityEngine;
using System.Collections;

public class SpeedChanger : MonoBehaviour
{
    public MoveCar ObjToMove;
    public float Speed;
    public ShipGrow Grow;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider col)
    {
        if (Grow != null)
            Grow.Activate = true;
        ObjToMove.gameObject.SetActive(true);
        ObjToMove.Speed = Speed;
    }
}
