using System.Collections.Generic;

using Items;

using LevelPOIs;

using UnityEngine;

using Random = UnityEngine.Random;

namespace Managers
{
    public class LevelManager : MonoBehaviour
    {
        public static LevelManager Instance;

        public List<Item> spawnedItems = new ();
        
        private ItemSpawnPoint[] _spawnPoints;
        
        [SerializeField]
        public bool shuffleItemsOnStart;

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
            _spawnPoints = FindObjectsOfType<ItemSpawnPoint>();

            if (shuffleItemsOnStart)
            {
                ShuffleItems();
            }
            
            foreach (var spawnPoint in _spawnPoints)
            {
                spawnPoint.SpawnItem();
            }
        }

        private void Update()
        {
            //Check if player has gotten enough items
        }

        private void ShuffleItems()
        {
            var length = _spawnPoints.Length;
            
            for (var i = length - 1; i > 0; i--)
            {
                var randomIndex = Random.Range(0, i + 1);
        
                (_spawnPoints[i].itemPrefab, _spawnPoints[randomIndex].itemPrefab) = 
                    (_spawnPoints[randomIndex].itemPrefab, _spawnPoints[i].itemPrefab);
            }
        }
    }
}