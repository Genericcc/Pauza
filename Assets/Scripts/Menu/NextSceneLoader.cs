using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu
{
    public class NextSceneLoader : MonoBehaviour
    {
        private void Update()
        {
            if (!isActiveAndEnabled)
            {
                return;
            }
            
            if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Space))
            {
                LoadNextScene();
            }
        }

        public void LoadNextScene()
        {
            SceneManager.LoadScene(2);
        }

        private void OnDisable()
        {
            LoadNextScene();
        }
    }
}