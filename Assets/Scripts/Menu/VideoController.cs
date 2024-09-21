using System;

using Unity.VisualScripting;

using UnityEngine;
using UnityEngine.Video;

namespace Menu
{
    public class VideoController : MonoBehaviour
    {
        private VideoPlayer _vc;

        private void Start()
        {
            _vc = GetComponent<VideoPlayer>();
            _vc.frame = 0;
            
            
            
        }
    }
}