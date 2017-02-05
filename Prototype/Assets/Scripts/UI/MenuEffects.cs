using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class MenuEffects : MonoBehaviour {

	// Use this for initialization
	void Start () 
    {
	    foreach (var item in GetMenuChildren())
	    {
	        Debug.Log(item.name);
	    }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    List<Transform> GetMenuChildren()
    {
        List<Transform> ls = new List<Transform>();
        foreach (Transform menuChild in GameObject.Find(this.name).transform)
        {
            ls.Add(menuChild);

            foreach (Transform menuChild2 in menuChild)
            {
                ls.Add(menuChild2);
            }
        }
        return ls;
    }
}
