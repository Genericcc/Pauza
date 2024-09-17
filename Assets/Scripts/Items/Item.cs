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
        
        private SphereCollider _collider;

        private void Start()
        {
            _collider = GetComponent<SphereCollider>();
            _collider.radius = itemData.pickUpRange;
            
            gameObject.layer = LayerMask.NameToLayer("Interactable");
        }

        public void Interact(Player player)
        {
            ItemInteract(player);
        }
 
        protected virtual void ItemInteract(Player player)
        {
            var newItem = Instantiate(this);
            var sphereCollider = newItem.GetComponent<SphereCollider>();
            Destroy(sphereCollider);
            
            player.Inventory.Add(newItem);
            
            Destroy(gameObject);
        }

        public bool CanInteract(Player player)
        {
            return ItemCanInteract();
        }

        protected virtual bool ItemCanInteract()
        {
            return true;
        }

        public virtual void Use(Player player)
        {
            Debug.Log("This item cannot be used as a weapon");
        }
    }
}