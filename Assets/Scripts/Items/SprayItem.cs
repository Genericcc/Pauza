using Activities;

using UnityEngine;

namespace Items
{
    public class SprayItem : Item
    {
        public float maxDistance = 5f;
        public float sprayRadius = 2f;
        public LayerMask layerMask;
        
        public float stunDuration = 2f;

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
                    termite.Stun(stunDuration);
                }
            }
        }
    }
} 