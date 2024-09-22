using System;
using System.Collections.Generic;
using System.Linq;

using Items;

using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    private Transform itemContainer;
    
    [SerializeField]
    private Transform currentItemTransform;
    
    public List<Item> items;

    public Item currentItem;

    public List<Item> cogs;

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
        if (item.ItemData.id == 333)
        {
            cogs.Add(item);
            Debug.Log("Cog added");
            return;
        }
        
        items.Add(item);

        item.transform.SetParent(itemContainer, false);

        if (item is SprayItem)
        {
            item.transform.position = currentItemTransform.position;
            currentItem = item;
        }
        
        Debug.Log("Spray added");
    }

    public void Remove(Item item)
    {
        if (items.Any())
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
                    Destroy(currentItem.gameObject);
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