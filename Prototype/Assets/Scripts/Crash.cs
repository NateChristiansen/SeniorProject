using UnityEngine;
using System.Collections;

public class Crash : MonoBehaviour
{
    public AudioSource Sound;
    private bool _activate;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (_activate && !Sound.isPlaying)
            Destroy(gameObject);
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "car")
        {
            _activate = true;
            gameObject.GetComponent<Renderer>().enabled = false;
            Sound.Play();
        }
    }
}
