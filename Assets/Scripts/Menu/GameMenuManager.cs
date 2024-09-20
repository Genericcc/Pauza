using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu
{
    public class GameMenuManager : MonoBehaviour
    {
        private Player _player;
        private GameObject _visual;

        private bool _isOpen;

        private void Start()
        {
            _player = Player.Instance;
            _visual = transform.GetChild(0).gameObject;
            _isOpen = false;
        }

        private void Update()
        {
            if (!Input.GetKeyDown(KeyCode.Escape))
            {
                return;
            }

            if (_isOpen)
            {
                Resume();
            }
            else
            {
                Stop();
            }
        }
        
        public void Stop()
        {
            _player.OnMenuOpened();
            _visual.gameObject.SetActive(true);
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            _isOpen = true;
        }
        
        public void Resume()
        {
            _player.OnMenuClosed();
            _visual.gameObject.SetActive(false);
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            _isOpen = false;
        }
        
        public void Quit()
        {
            SceneManager.LoadScene(0);
        }
    }
}
