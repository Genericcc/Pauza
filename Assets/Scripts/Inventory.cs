using System.Collections.Generic;
using System.Linq;

using Items;

using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<ItemData> items;

    public bool Contains(ItemData itemData)
    {
        return items.Any(x => x.id == itemData.id);
    }

    public void Add(ItemData itemData)
    {                        
        items.Add(itemData);
        
        Debug.Log("Item added");
    }

    public void Remove(ItemData itemData)
    {
        var matchingItem = items.FirstOrDefault(x => x.id == itemData.id);
        var success = items.Remove(matchingItem);
        
        if (success)
        {
            Debug.Log("Item removed");
        }
        else
        {
            Debug.Log("Failed to remove");
        }
    }
}