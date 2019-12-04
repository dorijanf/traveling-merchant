using UnityEngine;
using System.Collections.Generic;
/*
 * Item is a class which stores information about specific items which are then stored
 * in a the item databse (essentially a template for items)
 */

public class Item
{
    public bool isStackable;
    public int id;
    public int maxStackSize;
    public int inventoryId = 0;
    public string name;
    public string description;
    public Sprite icon;

    public Item(int id, string name, string description, int maxStackSize, bool isStackable)
    {
        this.id = id;
        this.name = name;
        this.description = description;
        this.maxStackSize = maxStackSize;
        this.isStackable = isStackable;
        this.icon = Resources.Load<Sprite>("Sprites/Resources/Items/" + name);
    }

    public Item(Item item)
    {
        this.id = item.id;
        this.name = item.name;
        this.description = item.description;
        this.maxStackSize = item.maxStackSize;
        this.isStackable = item.isStackable;
        this.icon = Resources.Load<Sprite>("Sprites/Resources/Items/" + item.name);
    }
}
