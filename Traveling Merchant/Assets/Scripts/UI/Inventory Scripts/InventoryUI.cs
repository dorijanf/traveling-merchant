using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * Script that describes the behavior of inventory UI
 */

public class InventoryUI : MonoBehaviour
{
    [Header("References:")]
    public List<ItemUI> itemsUI = new List<ItemUI>();
    public GameObject slotPrefab;
    public Transform slotPanel;

    [Space]
    [Header("Inventory Attributes:")]
    public int inventoryId;
    public int numberOfSlots;

    private void Awake()
    {
        for (int i = 0; i < numberOfSlots; i++)
        {
            GameObject instance = Instantiate(slotPrefab);
            instance.transform.SetParent(slotPanel);
            itemsUI.Add(instance.GetComponentInChildren<ItemUI>());
        }
    }

    public int UpdateSlot(int slot, Item item)
    {
        itemsUI[slot].UpdateItem(item);
        return slot;
    }

    public void AddNewItem(Item item)
    {
        int slot = UpdateSlot(itemsUI.FindIndex(i => i.item == null), item);
        itemsUI[slot].amount = 1;
    }

    public void RemoveItem(Item item)
    {
        UpdateSlot(itemsUI.FindIndex(i => i.item == item), null);
    }

    public void SetInventoryId(int inventoryId)
    {
        this.inventoryId = inventoryId;
    }
}