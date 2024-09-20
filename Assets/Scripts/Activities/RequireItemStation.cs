using System;
using System.Collections.Generic;
using System.Linq;

using Items;

using MEC;

using UnityEngine;

namespace Activities
{
    public class RequireItemStation : ActivityStation
    {
        [SerializeField]
        public Item requiredItem;
        
        // [SerializeField]
        // protected float interactTime;
        
        private Material _material;
        //private float _currentInteractTime;

        private void Awake()
        {
            _material = GetComponent<MeshRenderer>().material;
            _material.color = Color.red;
        }
        
        protected override bool CanInteractWith(Player player)
        {
            return player.Inventory.Contains(requiredItem.ItemData);
        }

        protected override IEnumerator<float> _Interact(Player player)
        {            
            player.Inventory.Remove(requiredItem);

            player.Freeze();
            CurrentInteractTime = interactTime;
            
            while (CurrentInteractTime > 0)
            {
                Debug.Log("Interacting...");

                CurrentInteractTime -= Time.deltaTime;
                yield return Timing.WaitForOneFrame;
            }

            isCompleted = true;
            _material.color = Color.green;
            player.Free();
        }
    }
}