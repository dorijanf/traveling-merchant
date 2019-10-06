using UnityEngine;

public class CartUI : MonoBehaviour
{
    public Transform itemsParent;
    Cart cart;
    InventorySlot[] inventorySlots;
    // Start is called before the first frame update
    void Start()
    {
        cart = Cart.instance;
        cart.onItemChangedCallback += UpdateUI;
        inventorySlots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void UpdateUI()
    {
        for(int i = 0; i < inventorySlots.Length; i++)
        {
            if(i < cart.items.Count)
            {
                inventorySlots[i].AddItem(cart.items[i]);
            }
            else
            {
                inventorySlots[i].RemoveItem();
            }
        }
    }
}
