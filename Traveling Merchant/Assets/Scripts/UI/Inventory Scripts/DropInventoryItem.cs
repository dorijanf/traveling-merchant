using UnityEngine;
using UnityEngine.EventSystems;

/*
 * Class that describes what happens when our player drops an item from the inventory
 */

public class DropInventoryItem : MonoBehaviour, IPointerClickHandler
{
    private ItemUI selectedItem;

    private void Awake()
    {
        selectedItem = GameObject.Find("SelectedItem").GetComponent<ItemUI>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(selectedItem.item != null)
        {
            if(gameObject != null)
            {
                selectedItem.amount = 0;
                selectedItem.text.text = "";
                selectedItem.UpdateItem(null);
            }
        }
    }
}
