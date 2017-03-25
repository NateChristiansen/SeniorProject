using UnityEngine;
using System.Collections;

public class RollingBoulder : MonoBehaviour
{

    public float Speed = 800.0f;

    private bool _startRolling = false;
    private Rigidbody _rb;
	// Use this for initialization
	void Start () 
    {
	    
	}
	
	// Update is called once per frame
	void FixedUpdate () 
    {
	    if (_startRolling)
	    {
	        _rb = GetComponent<Rigidbody>();
            Vector3 rollDirection = new Vector3(0f, 0f, 1f);
	        _rb.AddForce(rollDirection * Speed, ForceMode.Impulse);
            transform.Rotate(100 * Time.deltaTime, 0, 0);
	    }
    }

    public void SetStartRolling(bool setter)
    {
        _startRolling = setter;
    }
}
