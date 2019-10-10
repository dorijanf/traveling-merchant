using System.Collections.Generic;
using UnityEngine;

public class Cart : MonoBehaviour
{
    #region Singleton
    public static Cart instance;

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
    public GameObject cartUI;
    public int space = 15;

    public List<Item> items = new List<Item>();

    public bool Add(Item item)
    {
        if (items.Count >= space)
        {
            Debug.Log("Not enough room.");
            return false;
        }
        items.Add(item);

        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
        return true;
    }

    public void Remove(Item item)
    {
        items.Remove(item);
        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            cartUI.SetActive(true);
        }
        if (collision.gameObject.tag == "Item")
        {
            collision.gameObject.GetComponent<MoveItem>().StoreItem();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        cartUI.SetActive(false);
    }
}
