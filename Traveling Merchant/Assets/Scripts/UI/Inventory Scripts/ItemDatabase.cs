using System.Collections.Generic;
using UnityEngine;

/*
 * ItemDatabase describes the database where all 
 * items in the game are stored
 */

public class ItemDatabase : MonoBehaviour
{
    public List<Item> items = new List<Item>();

    private void Awake()
    {
        BuildDatabase();
    }

    public Item GetItem(int id)
    {
        return items.Find(item => item.id == id);
    }

    public Item GetItem(string name)
    {
        return items.Find(item => item.name == name);
    }

    private void BuildDatabase()
    {
        items = new List<Item>() {
            new Item(0, "Copper Ore", "A common material mined from Copper Veins and commonly used for building construction", 5, true),
            new Item(1, "Silver Ore", "A rare material mined from Silver Veins and commonly used for building magical stuff", 5, true)
            };
    }
}
