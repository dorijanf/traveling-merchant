using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;
    public int space;

    public List<Item> playerItems = new List<Item>();

    public bool Add(Item item)
    {
        if (playerItems.Count >= space)
        {
            Debug.Log("Not enough room.");
            return false;
        }
        playerItems.Add(item);

        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
        return true;
    }

    public void Remove(Item item)
    {
        playerItems.Remove(item);
        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
    }
}

