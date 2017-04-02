using UnityEngine;
using System.Collections;

public class CannonBehavior : MonoBehaviour {

	public Transform m_cannonRot;
	public Transform m_muzzle;
	public GameObject m_shotPrefab;
    public Transform Car;
    public UFOHealth UFO;
    public AudioSource Audio;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
        transform.LookAt(Car);
	}

    public void Fire()
    {
        GameObject go = GameObject.Instantiate(m_shotPrefab, m_muzzle.position, m_muzzle.rotation) as GameObject;
        go.GetComponent<ShotBehavior>().UFO = UFO;
        Audio.Play();
        GameObject.Destroy(go, 3f);
    }
}
