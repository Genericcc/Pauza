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

        public void SpawnItem()
        {
            _itemGameObject = Instantiate(itemPrefab, transform.position, Quaternion.identity);
            LevelManager.Instance.spawnedItems.Add(_itemGameObject);
        }
    }
}