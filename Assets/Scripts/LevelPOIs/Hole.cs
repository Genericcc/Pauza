using System;

using UnityEngine;

namespace LevelPOIs
{
    public class Hole : MonoBehaviour
    {
        private void Start()
        {
            gameObject.layer = LayerMask.NameToLayer("Hole");
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