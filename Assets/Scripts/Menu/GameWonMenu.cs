using System;
using System.Collections.Generic;

using MEC;

using Unity.VisualScripting;

using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu
{
    public class GameWonMenu : MonoBehaviour
    {
        [SerializeField]
        public GameObject quitButton;

        private void Start()
        {
            Cursor.visible = true;
        }
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Quit();
            }
        }
        
        public void Quit()
        {
            Application.Quit();
        }
    }
}