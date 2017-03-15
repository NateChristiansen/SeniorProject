using UnityEngine;
using System.Collections;

public class RockImpactSound : MonoBehaviour
{
    public AudioSource terrainSound;
    public AudioSource carSound;
    private int playTimes = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision col)
    {
        Debug.Log(col.gameObject.tag);
        if (col.gameObject.tag.Equals("terrain") && playTimes < 1)
        {
            terrainSound.Play();
            playTimes++;
        }

        if (col.gameObject.tag.Equals("car"))
        {
            terrainSound.Play();
            carSound.Play();
            playTimes++;
            // play rock and metal hitting sound
        }
    }
}
