using UnityEngine;

namespace Menu
{
    public class ButtonsSound : MonoBehaviour
    {
        public AudioSource myFx;
        public AudioClip hoverFx;
        public AudioClip clickFx;


        public void HoverSound()
        {
            myFx.PlayOneShot(hoverFx);
        }
        public void ClickSound()
        {
            myFx.PlayOneShot(clickFx);
        }

    }
}