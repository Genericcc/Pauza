using System;
using System.Collections.Generic;

using MEC;

using Unity.VisualScripting;

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


        private void Start()
        {
            Cursor.visible = true;
        }

        public void Play()
        {
            //SceneManager.LoadScene(1);
            Timing.RunCoroutine(_LoadLevel().CancelWith(gameObject));
        } 

        private IEnumerator<float> _LoadLevel()
        {
            yield return Timing.WaitForSeconds(1f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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