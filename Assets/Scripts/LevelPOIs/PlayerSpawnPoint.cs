using UnityEngine;

namespace LevelPOIs
{
    public class PlayerSpawnPoint : MonoBehaviour
    {
        private void Start()
        {
            var meshRenderer = GetComponent<MeshRenderer>();
            meshRenderer.enabled = false;
        }
    }
}