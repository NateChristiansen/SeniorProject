using UnityEngine;
using System.Collections;

public class Builder : MonoBehaviour
{

    public GameObject LavaGameObject;
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
        }
    }

    private void BuildLava()
    {
        LavaGameObject.SetActive(true);
    }
}
