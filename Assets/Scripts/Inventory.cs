using System;
using System.Collections.Generic;
using System.Linq;

using Items;

using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    private Transform itemContainer;
    
    public List<Item> items;

    public Item currentItem;

    private void Start()
    {
        items = new List<Item>();
    }

    public bool Contains(ItemData itemData)
    {
        return items.Any(x => x.ItemData.id == itemData.id);
    }

    public void Add(Item item)
    {                        
        items.Add(item);

        item.transform.position = itemContainer.position;
        item.transform.SetParent(itemContainer, false);

        currentItem = item;
        
        Debug.Log("Item added");
    }

    public void Remove(Item item)
    {
        var matchingItem = items.FirstOrDefault(x => x.ItemData.id == item.ItemData.id);

        if (matchingItem == currentItem)
        {
            if (items.Count > 2)
            {
                SelectNext();
            }
            else
            {
                currentItem = null;
            }
        }
        
        
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

    public void SelectNext()
    {
        if (!items.Any())
        {
            return;
        }
        
        currentItem = GetNext(items, currentItem);
    }

    private Item GetNext(List<Item> list, Item item)
    {
        var index = list.IndexOf(item);
        return index < list.Count - 1 
            ? list[index + 1] 
            : list[0];
    }

    public void SelectPrevious()
    {
        if (!items.Any())
        {
            return;
        }
        
        currentItem = GetPrevious(items, currentItem);
    }

    private Item GetPrevious(List<Item> list, Item item)
    {
        var index = list.IndexOf(item);
        return index > 0 
            ? list[index - 1] 
            : list[^1];
    }
}