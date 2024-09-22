using System;

using UnityEngine;
using UnityEngine.SceneManagement;

namespace EnterArea
{
    public class LoadLevelArea : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}