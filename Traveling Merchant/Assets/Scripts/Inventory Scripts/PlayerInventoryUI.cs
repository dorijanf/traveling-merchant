using UnityEngine;

public class PlayerInventoryUI : MonoBehaviour
{
    public Transform itemsParent;
    PlayerInventory inventory;
    PlayerInventorySlot[] inventorySlots;
    // Start is called before the first frame update
    void Start()
    {
        inventory = PlayerInventory.instance;
        inventory.onItemChangedCallback += UpdateUI;
        inventorySlots = itemsParent.GetComponentsInChildren<PlayerInventorySlot>();
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
