using UnityEngine;

namespace EnterArea
{
    public class WorldUIArea : MonoBehaviour
    {
        [SerializeField]
        private GameObject uiObject;

        private Player _player;
        private bool _isActive;

        private void Start()
        {
            _player = Player.Instance;
            
            _isActive = false;
            uiObject.SetActive(false);
        }

        // private void Update()
        // {
        //     if (_isActive)
        //     {
        //         uiObject.transform.rotation = Quaternion.LookRotation(_player.transform.position, Vector3.down);
        //     }
        // } 

        private void OnTriggerEnter(Collider other)
        {
            _isActive = true;
            uiObject.SetActive(true);
        }

        private void OnTriggerExit(Collider other)
        { 
            _isActive = false;
            uiObject.SetActive(false);
        }
    }
}