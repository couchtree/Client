using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    /// <summary>
    /// Class to load the next scene asynchronous
    /// </summary>
    public class SceneLoading : MonoBehaviour
    {
        //[SerializeField] private Image _progressBar;
        Scene scene;
        private void Start()
        {
            
            //LoadScene(2);
            if (SceneManager.GetActiveScene().buildIndex == 0)
            {
                if (PlayerPrefs.HasKey("story.startstory.read") && PlayerPrefs.GetInt("story.startstory.read") == 1)
                {
                    if (PlayerPrefs.HasKey("player.name") || PlayerPrefs.GetString("player.name") != "")
                    {
                        LoadScene(3, 2.8f);
                    }
                    else if (PlayerPrefs.HasKey("garden.name") || PlayerPrefs.GetString("garden.name") != "")
                    {
                        LoadScene(3, 2.8f);
                    }
                    else
                    {
                        LoadScene(2, 2.8f);
                    }
                }
                else
                {
                    LoadScene(1, 2.8f);
                }
            }
        }

        /// <summary>
        /// Load scene with set index directly
        /// </summary>
        /// <param name="scene">Index of the scene to be loaded</param>
        public void LoadScene(int scene)
        {
            StartCoroutine(LoadAsyncOperation(scene));
        }

        /// <summary>
        /// Load scene after some time
        /// </summary>
        /// <param name="scene">Index of the scene to be loaded</param>
        /// <param name="seconds">Time to wait before load is performed [s]</param>
        public void LoadScene(int scene, float seconds)
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
            // Assume that if the garden- and tree-name was saved all other this were saved as well
            if (PlayerPrefs.HasKey("garden.name") && PlayerPrefs.HasKey("tree.name"))
            {
                scene += 1;
            }
            SceneManager.LoadScene(scene);
        }

    }
}
