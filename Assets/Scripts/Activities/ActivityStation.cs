using System;
using System.Collections.Generic;

using MEC;

using UnityEngine;

namespace Activities
{
    public class ActivityStation : MonoBehaviour, IInteractable
    {
        [SerializeField]
        protected float interactTime;
        protected float CurrentInteractTime;
        
        public bool isCompleted;

        private void Start()
        {
            CurrentInteractTime = interactTime;
            isCompleted = false;
        }
        
        public void Interact(Player player)
        {                    
            Timing.RunCoroutine(_Interact(player));
        }

        protected virtual IEnumerator<float> _Interact(Player player)
        {
            player.Freeze();
            CurrentInteractTime = interactTime;
            
            while (CurrentInteractTime > 0)
            {
                Debug.Log("Interacting...");

                CurrentInteractTime -= Time.deltaTime;
                yield return Timing.WaitForOneFrame;
            }

            isCompleted = true;
            player.Free();
        }

        public bool CanInteract(Player player)
        {
            return CanInteractWith(player);
        }

        protected virtual bool CanInteractWith(Player player)
        {
            return true;
        }
    }
}