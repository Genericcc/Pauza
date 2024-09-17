﻿using System.Collections.Generic;
using System.Linq;

using Items;

using MEC;

using UnityEngine;

namespace Activities
{
    public class RequireItemStation : MonoBehaviour, IInteractable
    {
        [SerializeField]
        public Item requiredItem;
        
        [SerializeField]
        protected float interactTime;
        
        private float _currentInteractTime;
        
        public void Interact(Player player)
        {                    
            player.Inventory.Remove(requiredItem);
            
            Timing.RunCoroutine(_Interact(player));
        }
        
        public bool CanInteract(Player player)
        {
            return player.Inventory.Contains(requiredItem.ItemData);
        }

        private IEnumerator<float> _Interact(Player player)
        {
            player.Freeze();
            _currentInteractTime = interactTime;
            
            while (_currentInteractTime > 0)
            {
                Debug.Log("Interacting...");

                _currentInteractTime -= Time.deltaTime;
                yield return Timing.WaitForOneFrame;
            }

            player.Free();
        }
    }
}