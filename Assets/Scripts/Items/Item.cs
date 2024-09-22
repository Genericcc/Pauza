using System;
using System.Collections.Generic;

using Activities;

using MEC;

using UnityEngine;

namespace Items
{
    public class Item : MonoBehaviour, IInteractable
    {
        [SerializeField]
        private ItemData itemData;
        public ItemData ItemData => itemData;

        [SerializeField]
        private float interactionTime;

        protected float _timeSinceInteractionStart;
        
        private SphereCollider _collider;

        public virtual void Start()
        {
            _collider = GetComponent<SphereCollider>();
            _collider.radius = itemData.pickUpRange;
            _timeSinceInteractionStart = 0f;
            
            gameObject.layer = LayerMask.NameToLayer("Interactable");
        }

        public void Interact(Player player)
        {
            Timing.RunCoroutine(ItemInteract(player).CancelWith(player.gameObject));
        }
 
        protected virtual IEnumerator<float> ItemInteract(Player player)
        {
            Debug.Log("Picking up cog");
            yield return Timing.WaitForSeconds(_timeSinceInteractionStart);
            Debug.Log($"Picked up {gameObject.name}");
            
            gameObject.SetActive(false);
            // var mesh = GetComponentInChildren<MeshRenderer>();
            // Destroy(mesh);
            Destroy(_collider);
            
            player.Inventory.Add(this);
            
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