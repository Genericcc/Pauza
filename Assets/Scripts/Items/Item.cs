using System;

using Activities;

using UnityEngine;

namespace Items
{
    public class Item : MonoBehaviour, IInteractable
    {
        [SerializeField]
        private ItemData itemData;
        public ItemData ItemData => itemData;

        [SerializeField]
        private float pickUpRange;
        
        private SphereCollider _collider;

        private void Start()
        {
            _collider = GetComponent<SphereCollider>();
            _collider.radius = itemData.pickUpRange;
        }

        public void Interact(Player player)
        {
            player.Inventory.Add(itemData);
            
            Destroy(gameObject,0.1f);
        }

        public bool CanInteract(Player player)
        {
            return true;
        }
    }
}