using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class Menu_StartGame : MonoBehaviour, IGvrGazeResponder
    {
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
            async = SceneManager.LoadSceneAsync("mainScene");
            async.allowSceneActivation = false;
            yield return async;
        }

        public void OnGazeEnter()
        {
        
        }

        public void OnGazeExit()
        {
        
        }

        public void OnGazeTrigger()
        {
            if (async != null)
                async.allowSceneActivation = true;
        }
    }
}
