using System;

using Items;

using Managers;

using UnityEngine;

namespace LevelPOIs
{
    public class ItemSpawnPoint : MonoBehaviour
    {
        [SerializeField]
        public Item itemPrefab;

        private Item _itemGameObject;

        private void Start()
        {
            var meshRenderer = GetComponent<MeshRenderer>();
            meshRenderer.enabled = false;
        }

        public void SpawnItem()
        {
            _itemGameObject = Instantiate(itemPrefab, transform.position, Quaternion.identity);
            LevelManager.Instance.spawnedItems.Add(_itemGameObject);
        }
    }
}