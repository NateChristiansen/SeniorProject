using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{

    public string SceneToLoad;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag.Equals("car"))
        {
            SceneManager.LoadScene(SceneToLoad);
        }
    }
}
