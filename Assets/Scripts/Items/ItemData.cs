using UnityEngine;

namespace Items
{
    [CreateAssetMenu(fileName = "ItemData", menuName = "Items/ItemData", order = 1)]
    public class ItemData : ScriptableObject
    {
        public int id;
        public Sprite sprite;
        public float pickUpRange;
    }
}