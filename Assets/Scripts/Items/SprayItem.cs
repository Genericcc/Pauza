﻿using System.Collections.Generic;

using Activities;

using MEC;

using UnityEngine;

namespace Items
{
    public class SprayItem : Item
    {
        public float maxDistance = 5f;
        public float sprayRadius = 2f;
        public LayerMask layerMask;
        
        public float stunDuration = 2f;

        public AudioSource AudioSource { get; private set; }

        public override void Start()
        {
            base.Start();
            
             AudioSource = GetComponent<AudioSource>();
        }
        
        public override void Use(Player player)
        {
            Debug.Log("Spray and pray!");

            var playerPosition = player.transform.position;
            var playerForward = player.transform.forward;
            
            var farthestSprayReach = playerPosition + playerForward * maxDistance;

            var colliders = Physics.OverlapCapsule(playerPosition, farthestSprayReach, sprayRadius, layerMask);

            foreach (var collider in colliders)
            {
                Debug.Log($"Collide with {collider.gameObject.name}");

                if (collider.gameObject.TryGetComponent<Termite>(out var termite))
                {
                    if (AudioSource != null)
                    {
                        AudioSource.Play();
                    }

                    termite.Stun(stunDuration);
                }
            }
            
            player.Inventory.Remove(this);
        }

        protected override IEnumerator<float> ItemInteract(Player player)
        {
            Debug.Log("Picking up the spray");
            yield return Timing.WaitForSeconds(_timeSinceInteractionStart);
            Debug.Log($"Picked up {gameObject.name}");
            
            var newItem = Instantiate(this);
            var sphereCollider = newItem.GetComponent<SphereCollider>();
            Destroy(sphereCollider);
            
            player.Inventory.Add(newItem);
            
            Destroy(gameObject);
        }
    }
} 