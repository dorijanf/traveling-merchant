using UnityEngine;
using UnityEngine.UI;

public class PlayerInventorySlot : MonoBehaviour
{
    [Space]
    [Header("References:")]
    public Image icon;
    public Button removeButton;
    private Item item;

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
        PlayerInventory.instance.Remove(item);
    }
}
