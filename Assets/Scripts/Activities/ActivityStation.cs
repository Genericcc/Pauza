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
        
        private float _currentInteractTime;
        
        private void Start()
        {
            _currentInteractTime = interactTime;
        }
        
        public void Interact(Player player)
        {                    
            Timing.RunCoroutine(_Interact(player));
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

        public bool CanInteract(Player player)
        {
            return true;
        }

    }
}