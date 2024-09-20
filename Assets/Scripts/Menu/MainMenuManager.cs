using System.Collections.Generic;

using MEC;

using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu
{
    public class MainMenuManager : MonoBehaviour
    {
        [SerializeField]
        public GameObject controlsView;
        
        [SerializeField]
        public GameObject creditsView;
        
        [SerializeField]
        public GameObject buttonsPanel;
        
        public void Play()
        {
            Timing.RunCoroutine(_LoadLevel().CancelWith(gameObject));
        }

        private IEnumerator<float> _LoadLevel()
        {
            yield return Timing.WaitForSeconds(1);
            SceneManager.LoadScene(1);
        }

        public void OpenControls()
        {
            controlsView.SetActive(true);
            buttonsPanel.SetActive(false);
        }

        public void CloseControls()
        {
            controlsView.SetActive(false);
            buttonsPanel.SetActive(true);
        }
        
        public void OpenCredits()
        {
            creditsView.SetActive(true);
            buttonsPanel.SetActive(false);
        }
        
        public void CloseCredits()
        {
            creditsView.SetActive(false);
            buttonsPanel.SetActive(true);
        }
        
        public void Quit()
        {
            Application.Quit();
        }
    }
}