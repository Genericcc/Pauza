using Unity.VisualScripting;

using UnityEngine;

namespace UIs
{
    public class Serduszka : MonoBehaviour
    {
        [SerializeField] private GameObject heart1;
        [SerializeField] private GameObject heart2;
        [SerializeField] private GameObject heart3;
        
        private Player _player;

        private void Start()
        {
            _player = Player.Instance;
        }

        private void Update()
        {
            if (_player.CurrentHp == 3)
            {
                heart1.SetActive(true);
                heart2.SetActive(true);
                heart3.SetActive(true);
            }
            else if (_player.CurrentHp == 2)
            {
                heart1.SetActive(true);
                heart2.SetActive(true);
                heart3.SetActive(false);
            }
            else if (_player.CurrentHp == 1)
            {
                heart1.SetActive(true);
                heart2.SetActive(false);
                heart3.SetActive(false);
            }
            else
            {
                heart1.SetActive(false);
                heart2.SetActive(false);
                heart3.SetActive(false);
            }
        }
    }
}
