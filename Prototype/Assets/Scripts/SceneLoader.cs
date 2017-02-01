using UnityEngine;
using System.Collections;

public class SceneLoader : MonoBehaviour {

	// Use this for initialization
    public GameObject MainCamera;
    public GameObject DarkCamera;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag.Equals("frontTunnelBlock"))
        {
            GameObject.Find("BeginExperience").gameObject.GetComponent<StartMenu>().StartGame();
        }

    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2);
    }
}
