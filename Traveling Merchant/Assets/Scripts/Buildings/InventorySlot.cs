using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    [Space]
    [Header("References:")]
    public Image icon;
    public Button removeButton;
    public Inventory inventory;
    private Item item;

    private void Start()
    {
        inventory = GetComponent<Inventory>();
    }

    public void AddItem(Item newItem)
    {
        item = newItem;
        icon.sprite = item.icon;
        icon.enabled = true;
        removeButton.interactable = true;
    }

    public void RemoveItem()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
        removeButton.interactable = false;
    }

    public void OnRemoveButton()
    {
        inventory.Remove(item);
    }
}
