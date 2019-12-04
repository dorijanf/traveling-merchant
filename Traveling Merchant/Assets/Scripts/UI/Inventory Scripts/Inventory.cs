using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [Header("References:")]
    public int inventoryId;
    public List<Item> inventoryItems = new List<Item>();
    public ItemDatabase itemDatabase;
    public InventoryUI inventoryUI;

    private void Awake()
    {
        InventoryDatabase.AddNewInventory(gameObject);
        inventoryId = InventoryDatabase.inventory.Count - 1;
        inventoryUI.SetInventoryId(inventoryId);
        inventoryUI.inventoryId = inventoryId;
        InventoryDatabase.AddNewInventoryUI(inventoryUI.gameObject);
    }

    private bool CheckIfItemInInventory(Item item)
    {
        for (int i = 0; i < inventoryItems.Count; i++)
        {
            if (item.id == inventoryItems[i].id)
            {
                return true;
            }
        }
        return false;
    }

    public bool GiveItem(int id, int inventoryId)
    {
        Item itemToAdd = itemDatabase.GetItem(id);
        if(itemToAdd.isStackable && CheckIfItemInInventory(itemToAdd))
        {
            for(int i = 0; i < InventoryDatabase.inventoryUI[inventoryId].itemsUI.Count; i++)
            {
                if (InventoryDatabase.inventoryUI[inventoryId].itemsUI[i].item != null)
                {
                    if (InventoryDatabase.inventoryUI[inventoryId].itemsUI[i].item.id == id && InventoryDatabase.inventoryUI[inventoryId].itemsUI[i].amount < itemToAdd.maxStackSize)
                    {
                        InventoryDatabase.inventoryUI[inventoryId].itemsUI[i].amount++;
                        InventoryDatabase.inventoryUI[inventoryId].itemsUI[i].transform.GetChild(0).GetComponent<Text>().text = InventoryDatabase.inventoryUI[inventoryId].itemsUI[i].amount.ToString();
                        return true;
                    }
                }
            }
        }

        if (inventoryItems.Count < inventoryUI.numberOfSlots)
        {
            InventoryDatabase.inventory[inventoryId].inventoryItems.Add(itemToAdd);
            InventoryDatabase.inventoryUI[inventoryId].AddNewItem(itemToAdd);
            Debug.Log("Item (" + id + ")" + " has been added to inventory (" + inventoryId + ")");
            return true;
        }
        else
        {
            Debug.Log("Inventory is full.");
            return false;
        }
    }

    public bool GiveItemFromInventory(int id, int inventoryId)
    {
        if (InventoryDatabase.inventory[inventoryId].inventoryItems.Count < InventoryDatabase.inventoryUI[inventoryId].numberOfSlots)
        {
            Item itemToAdd = itemDatabase.GetItem(id);
            InventoryDatabase.inventory[inventoryId].inventoryItems.Add(itemToAdd);
            Debug.Log("Inventory (" + inventoryId + ") size after give: " + InventoryDatabase.inventory[inventoryId].inventoryItems.Count);
            return true;
        }
        else
        {
            Debug.Log("Inventory is full.");
            return false;
        }
    }

    public Item CheckForItem(int id, int inventoryId)
    {
        return InventoryDatabase.inventory[inventoryId].inventoryItems.Find(Item => Item.id == id);
    }

    public void RemoveItem(int id, int inventoryId)
    {
        Item itemToRemove = CheckForItem(id, inventoryId);
        if(itemToRemove != null)
        {
            inventoryItems.Remove(itemToRemove);
            Debug.Log("Inventory (" + inventoryId + ") size after remove: " + inventoryItems.Count);
        }
    }
}

