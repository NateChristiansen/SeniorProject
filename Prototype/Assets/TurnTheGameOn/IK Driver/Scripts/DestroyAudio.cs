using UnityEngine;
using System.Collections;

public class DestroyAudio : MonoBehaviour {

	void Update () {
		if(!GetComponent<AudioSource>().isPlaying){
			Destroy(gameObject);
		}
	}
}