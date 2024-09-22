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
        private Item requiredMainKeyItem;
        
        [SerializeField]
        private Item cogPrefab;

        [SerializeField]
        private int numberOfRequiredCogs;
        
        protected override bool CanInteractWith(Player player)
        {
            if (!player.Inventory.Contains(requiredMainKeyItem.ItemData))
            {
                return false;
            }

            // if (!player.Inventory.items.Contains(requiredMainKeyItem.ItemData))
            // {
            //     return false;
            // }

            return true;
        }

        protected override IEnumerator<float> _Interact(Player player)
        {            
            player.Inventory.Remove(requiredMainKeyItem);

            player.Freeze();
            CurrentInteractTime = interactTime;

            yield return Timing.WaitForSeconds(interactTime);
            
            // CurrentInteractTime = interactTime;
            //
            // while (CurrentInteractTime > 0)
            // {
            //     Debug.Log("Interacting...");
            //
            //     CurrentInteractTime -= Time.deltaTime;
            //     yield return Timing.WaitForOneFrame;
            // }return Timing.WaitForOneFrame;

            isCompleted = true;
            player.Free();
        }
    }
}