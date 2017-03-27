using UnityEngine;
using System.Collections;

public class Builder : MonoBehaviour
{

    public GameObject LavaGameObject;
    public GameObject Animation2Parent;
    public GameObject Orbs2Parent;
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
            BuildLava();
            BuildAnimation2();
            BuildOrbs2();
        }
    }

    private void BuildLava()
    {
        LavaGameObject.SetActive(true);
    }

    private void BuildAnimation2()
    {
        Animation2Parent.SetActive(true);
    }

    private void BuildOrbs2()
    {
        Orbs2Parent.SetActive(true);
    }
}
