using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class SceneLoading : MonoBehaviour
    {
        //[SerializeField] private Image _progressBar;
        Scene scene;
        private void Start()
        {
            
            //LoadScene(2);
            if (SceneManager.GetActiveScene().buildIndex == 0)
            {
                LoadScene(1, 2.8f);

            }
        }

        public void LoadScene(int scene)
        {
            StartCoroutine(LoadAsyncOperation(scene));
        }

        public void LoadScene(int scene,float seconds)
        {
            StartCoroutine(WaitWithSceneLoading(scene, seconds));
        }

        private IEnumerator LoadAsyncOperation(int scene)
        {
            // Scene will automatic be loaded when its loaded...
            AsyncOperation nextScene = SceneManager.LoadSceneAsync(scene);

            while (!nextScene.isDone)
            {
                //_progressBar.fillAmount = nextScene.progress;
                yield return new WaitForEndOfFrame();
            }
            
            yield return new WaitForEndOfFrame();
        }

        private IEnumerator WaitWithSceneLoading(int scene, float seconds)
        {
            yield return new WaitForSeconds(seconds);
            SceneManager.LoadScene(scene);
        }

    }
}
