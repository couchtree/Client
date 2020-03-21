using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class SceneLoading : MonoBehaviour
    {
        [SerializeField] private Image _progressBar;

        private void Start()
        {
            //LoadScene(2);
        }

        public void LoadScene(int scene)
        {
            StartCoroutine(LoadAsyncOperation(scene));
        }

        private IEnumerator LoadAsyncOperation(int scene)
        {
            // Scene will automatic be loaded when its loaded...
            AsyncOperation nextScene = SceneManager.LoadSceneAsync(scene);

            while (!nextScene.isDone)
            {
                _progressBar.fillAmount = nextScene.progress;
                yield return new WaitForEndOfFrame();
            }
            
            yield return new WaitForEndOfFrame();
        }
    }
}
