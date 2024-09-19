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

        public Item SpawnItem()
        {
            _itemGameObject = Instantiate(itemPrefab);
            
            return _itemGameObject;
        }
    }
}