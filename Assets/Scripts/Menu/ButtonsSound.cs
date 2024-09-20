using System;

using UnityEngine;

namespace Menu
{
    public class ButtonsSound : MonoBehaviour
    {
        public AudioSource myFx;
        public AudioClip hoverFx;
        public AudioClip clickFx;
        
        private SoundManager _soundManager;

        private void Start()
        {
            _soundManager = FindObjectOfType<SoundManager>();
        }

        public void HoverSound()
        {
            if (_soundManager != null)
            {
                _soundManager.PlaySound(hoverFx);
            }
            else
            {
                Debug.LogWarning("Sound Manager not found");
            }
            //myFx.PlayOneShot(hoverFx);
        }
        
        public void ClickSound()
        {
            if (_soundManager != null)
            {
                _soundManager.PlaySound(clickFx);
            }
            else
            {
                Debug.LogWarning("Sound Manager not found");
            }
            //myFx.PlayOneShot(clickFx);
        }
    }
}