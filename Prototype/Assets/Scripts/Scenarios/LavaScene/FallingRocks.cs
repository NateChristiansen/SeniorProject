using UnityEngine;
using System.Collections;

/*
 * Script is used to make rocks fall and play a sound to alert the user before this action occurs
 */
public class FallingRocks : MonoBehaviour
{

    public GameObject RockParentObject;
    public AudioSource UserAlertSound;
    public GameObject ScenarioPackage;
    private bool _rocksFell;
    private float _rockLifeTime = 15;

	// Use this for initialization
	void Start ()
	{
	    _rocksFell = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
	    if (_rocksFell)
	    {
	        _rockLifeTime -= Time.deltaTime;
	    }

        if (_rocksFell && _rockLifeTime <= 0)
	    {
            Destroy(ScenarioPackage);
	    }
	}

    /// <summary>
    /// Rocks will be affected by gravity
    /// </summary>
    void EnabledRockFall()
    {
        foreach (Transform child in RockParentObject.transform)
        {
            child.gameObject.GetComponent<Rigidbody>().useGravity = true;
            child.gameObject.GetComponent<Rigidbody>().isKinematic = false;
        }
    }

    void MakeRocksVisible()
    {
        foreach (Transform child in RockParentObject.transform)
        {
            child.gameObject.SetActive(true);
        }
    }

    /// <summary>
    /// Alerts the user prior to the scenario
    /// </summary>
    void PlayAlertSound()
    {
        UserAlertSound.Play();
    }

    /// <summary>
    /// The rocks will fall when this trigger collides with the car
    /// </summary>
    /// <param name="col">The object colliding with the trigger</param>
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag.Equals("car"))
        {
            MakeRocksVisible();
            PlayAlertSound(); // alert the user of scenario
            EnabledRockFall(); // enabled the rocks to fall
            _rocksFell = true;
        }
    }
}
