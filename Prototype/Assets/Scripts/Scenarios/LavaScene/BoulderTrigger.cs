using UnityEngine;
using System.Collections;

public class BoulderTrigger : MonoBehaviour
{

    public GameObject LargeBoulder;
    public GameObject SmallBoulder1;
    public GameObject SmallBoulder2;
    public AudioSource AlertSound;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag.Equals("car"))
        {
            LargeBoulder.GetComponent<RollingBoulder>().SetStartRolling(true);
            SmallBoulder1.GetComponent<RollingBoulder>().SetStartRolling(true);
            SmallBoulder2.GetComponent<RollingBoulder>().SetStartRolling(true);
            AlertSound.Play();
        }
    }
}
