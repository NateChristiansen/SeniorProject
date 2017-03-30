using UnityEngine;
using System.Collections;

public class ActivateTutorial : MonoBehaviour
{
    public TutorialText Tutorial;
    private bool _lock;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider col)
    {
        if (_lock)
            Tutorial.gameObject.SetActive(true);
        _lock = true;
    }
}
