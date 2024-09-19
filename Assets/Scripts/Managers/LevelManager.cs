using System;
using System.Collections.Generic;

using Items;

using LevelPOIs;

using UnityEngine;

namespace Managers
{
    public class LevelManager : MonoBehaviour
    {
        public static LevelManager Instance;
        
        [SerializeField]
        public List<Item> itemsToSpawn;
        
        [SerializeField]
        public List<ItemSpawnPoint> itemSpawnPoints;

        private List<Item> _spawnedItems;

        public LevelManager(List<Item> spawnedItems)
        {
            _spawnedItems = spawnedItems;
        }

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
            }

            Instance = this;
        }

        private void Start()
        {
            SpawnItems();
        }

        public void SpawnItems()
        {
            foreach (var itemSpawnPoint in itemSpawnPoints)
            {
                var newItem = itemSpawnPoint.SpawnItem();
                _spawnedItems.Add(newItem);
            }
        }
    }
}