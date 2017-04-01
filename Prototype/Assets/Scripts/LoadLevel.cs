using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour {

    private AsyncOperation async;
    // Use this for initialization
    void Start ()
    {
        StartCoroutine(Load());
    }
	
	// Update is called once per frame
	void Update () {

    }

    IEnumerator Load()
    {
        async = SceneManager.LoadSceneAsync("spaceScene");
        async.allowSceneActivation = false;
        yield return async;
    }

    void OnTriggerEnter(Collider col)
    {
        if (async != null && col.gameObject.tag == "car")
            async.allowSceneActivation = true;
    }
}
