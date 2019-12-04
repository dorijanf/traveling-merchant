using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform itemsParent;
    private Inventory inventory;
    private InventorySlot[] inventorySlots;
    // Start is called before the first frame update
    void Start()
    {
        inventory = GetComponent<Inventory>();
        inventory.onItemChangedCallback += UpdateUI;
        inventorySlots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }

    void UpdateUI()
    {
        for(int i = 0; i < inventorySlots.Length; i++)
        {
            if(i < inventory.playerItems.Count)
            {
                inventorySlots[i].AddItem(inventory.playerItems[i]);
            }
            else
            {
                inventorySlots[i].RemoveItem();
            }
        }
    }
}
