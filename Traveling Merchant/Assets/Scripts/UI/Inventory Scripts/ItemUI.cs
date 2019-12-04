using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemUI : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [Header("References:")]
    public Item item;
    public Text text;
    public int amount;
    public EnterAmount enterAmount;
    private Image spriteImage;
    private ItemUI selectedItem;
    private Tooltip tooltip;
    private GameObject dropSpace;
    private int inventoryId;

    private void Awake()
    {
        amount = 0;
        spriteImage = GetComponent<Image>();
        UpdateItem(null);
        selectedItem = GameObject.Find("SelectedItem").GetComponent<ItemUI>();
        tooltip = GameObject.Find("Tooltip").GetComponent<Tooltip>();
        dropSpace = GameObject.Find("DropSpace");

        //inventoryId = transform.parent.parent.parent.GetComponent<InventoryUI>().inventoryId;
    }

    public ItemUI(Item item, int amount)
    {
        this.item = item;
        this.amount = amount;
    }

    private void Start()
    {
        if (gameObject.name != "SelectedItem")
        {
            inventoryId = transform.parent.parent.parent.GetComponent<InventoryUI>().inventoryId;
        }
    }

    public void UpdateItem(Item item)
    {
        this.item = item;
        if (this.item != null)
        {
            spriteImage.color = Color.white;
            spriteImage.sprite = this.item.icon;
        }
        else
        {
            spriteImage.color = Color.clear;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        ItemUI clickedSlot = gameObject.GetComponent<ItemUI>();
        if (item != null)
        {
            InventoryDatabase.inventory[inventoryId].RemoveItem(item.id, inventoryId);
            if (selectedItem.item != null)
            {
                InventoryDatabase.inventory[inventoryId].GiveItemFromInventory(item.id, inventoryId);
                Debug.Log(clickedSlot.amount);
                Item clone = selectedItem.item;
                int cloneAmount = selectedItem.amount;

                selectedItem.UpdateItem(clickedSlot.item);
                selectedItem.amount = clickedSlot.amount;
                if (selectedItem.amount != 1)
                {
                    selectedItem.text.text = clickedSlot.amount.ToString();
                }
                else
                {
                    selectedItem.text.text = "";
                }

                clickedSlot.UpdateItem(clone);
                clickedSlot.amount = cloneAmount;
                if (clickedSlot.amount != 1)
                {
                    clickedSlot.text.text = cloneAmount.ToString();
                }
                else
                {
                    clickedSlot.text.text = "";
                }
            }
            else
            {
                enterAmount.EnterIntAmount();
                selectedItem.amount = clickedSlot.amount;
                if (selectedItem.amount != 1)
                {
                    selectedItem.text.text = clickedSlot.amount.ToString();
                }
                else
                {
                    selectedItem.text.text = "";
                }
                clickedSlot.amount = 0;
                clickedSlot.text.text = "";
                selectedItem.UpdateItem(item);
                UpdateItem(null);
            }
        }
        else if(selectedItem.item != null)
        {
            UpdateItem(selectedItem.item);
            selectedItem.UpdateItem(null);
            selectedItem.text.text = "";
            InventoryDatabase.inventory[inventoryId].GiveItemFromInventory(item.id, inventoryId);
            clickedSlot.amount = selectedItem.amount;
            if (clickedSlot.amount != 1)
            {
                clickedSlot.text.text = selectedItem.amount.ToString();
            }
            else
            {
                clickedSlot.text.text = "";
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (item != null)
        {
            tooltip.GenerateTooltip(item);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tooltip.gameObject.SetActive(false);
    }
}
