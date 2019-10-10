using System.Collections.Generic;
using UnityEngine;

public class CartInventory : MonoBehaviour
{
    #region Singleton
    public static CartInventory instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found!");
            return;
        }

        instance = this;
    }
    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;
    public GameObject inventoryUI;
    public int space;

    public List<Item> cartItems = new List<Item>();

    public bool Add(Item item)
    {
        if (cartItems.Count >= space)
        {
            Debug.Log("Not enough room.");
            return false;
        }
        cartItems.Add(item);

        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
        return true;
    }

    public void Remove(Item item)
    {
        cartItems.Remove(item);
        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            inventoryUI.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        inventoryUI.SetActive(false);
    }
}
