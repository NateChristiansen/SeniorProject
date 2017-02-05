using UnityEngine;
using System.Collections;

public class SceneLoader : MonoBehaviour {

	// Use this for initialization
    public Camera MainCamera;
    public Camera DarkCamera;

    private bool trigger = false;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag.Equals("frontTunnelBlock") && !trigger)
        {

            var child = GameObject.FindGameObjectWithTag("mainCamera").transform;
            child.gameObject.transform.parent = null;
            MainCamera.transform.position = GameObject.Find("tempPos").transform.position;
            MainCamera.transform.rotation = GameObject.Find("tempPos").transform.rotation;
            GameObject.Find("BeginExperience").gameObject.GetComponent<StartMenu>().StartGame();

            trigger = true;
        }

    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2);
    }
}
