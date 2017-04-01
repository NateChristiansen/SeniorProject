using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TransSetup : MonoBehaviour {

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
            // get current scene name
            string sceneName = SceneManager.GetActiveScene().name;

            // set name in the transition controller
            if (sceneName.Equals("jungleScene"))
            {
                TransController.CompletedLevel = "jungleScene";
            }
            else if (sceneName.Equals("lavaScene"))
            {
                TransController.CompletedLevel = "lavaScene";
            }
            else if (sceneName.Equals("spaceScene"))
            {
                TransController.CompletedLevel = "spaceScene";
            }

            // Load transition scene
            SceneManager.LoadScene("transitionScene");

        }
    }
}
