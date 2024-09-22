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
        private GameObject blocker;

        [SerializeField]
        private int numberOfRequiredCogs;
        
        protected override bool CanInteractWith(Player player)
        {
            if (requiredMainKeyItem != null)
            {
                if (!player.Inventory.Contains(requiredMainKeyItem.ItemData))
                {
                    return false;
                }
            }

            if (player.Inventory.cogs.Count < numberOfRequiredCogs)
            {
                return false;
            }

            return true;
        }

        protected override IEnumerator<float> _Interact(Player player)
        {            
            player.Inventory.Remove(requiredMainKeyItem);

            player.Freeze();
            
            var particles = Instantiate(player.fixParticles, transform.position, Quaternion.identity);
            var particles2 = Instantiate(player.fixParticles, transform.position, Quaternion.identity);
            var particles3 = Instantiate(player.fixParticles, transform.position, Quaternion.identity);
            var particles4 = Instantiate(player.fixParticles, transform.position, Quaternion.identity);
            var particles5 = Instantiate(player.fixParticles, transform.position, Quaternion.identity);
            
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
            
            Destroy(particles.gameObject);
            Destroy(particles2.gameObject);
            Destroy(particles3.gameObject);
            Destroy(particles4.gameObject);
            Destroy(particles5.gameObject);

            isCompleted = true;
            player.Free();
            
            blocker.SetActive(false);
        }
    }
}