﻿using UnityEngine;

namespace LevelPOIs
{
    public class TermiteSpawnPoint : MonoBehaviour
    {
        private void Start()
        {
            var meshRenderer = GetComponent<MeshRenderer>();
            meshRenderer.enabled = false;
        }
    }
}