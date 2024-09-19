using System;

using UnityEngine;

namespace LevelPOIs
{
    public class Hole : MonoBehaviour
    {
        private void Start()
        {
            
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                Debug.Log("Player entered hole");
            }
        }
    }
}