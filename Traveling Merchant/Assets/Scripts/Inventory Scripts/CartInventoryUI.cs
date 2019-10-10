using UnityEngine;

public class CartInventoryUI : MonoBehaviour
{
    public Transform itemsParent;
    CartInventory inventory;
    CartInventorySlot[] inventorySlots;
    // Start is called before the first frame update
    void Start()
    {
        inventory = CartInventory.instance;
        inventory.onItemChangedCallback += UpdateUI;
        inventorySlots = itemsParent.GetComponentsInChildren<CartInventorySlot>();
    }

    void UpdateUI()
    {
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            if (i < inventory.cartItems.Count)
            {
                inventorySlots[i].AddItem(inventory.cartItems[i]);
            }
            else
            {
                inventorySlots[i].RemoveItem();
            }
        }
    }
}
