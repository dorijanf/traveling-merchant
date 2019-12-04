using System.Collections.Generic;
using UnityEngine;

public static class InventoryDatabase
{
    public static List<Inventory> inventory = new List<Inventory>();
    public static List<InventoryUI> inventoryUI = new List<InventoryUI>();

    public static void AddNewInventory(GameObject gameObject)
    {
        inventory.Add(gameObject.GetComponent<Inventory>());
    }

    public static void AddNewInventoryUI(GameObject gameObject)
    {
        inventoryUI.Add(gameObject.GetComponent<InventoryUI>());
    }
}
