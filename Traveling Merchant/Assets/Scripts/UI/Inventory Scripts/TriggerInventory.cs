using UnityEngine;

/*
 * TriggerInventory is a script that opens the inventory on keypress if the player
 * is near the cart
 */

public class TriggerInventory : MonoBehaviour
{
    [Header("References:")]
    public GameObject inventory;
    public IsNearObject isNearObject;

    private void Update()
    {
        openInventory();
        InventorySetActive();
    }

    private void InventorySetActive()
    {
        if (!isNearObject.CheckIsNearObject())
        {
            inventory.SetActive(false);
        }
    }

    private void openInventory()
    {
        if (isNearObject.CheckIsNearObject())
        {
            if(Input.GetKeyDown(KeyCode.I) && inventory.activeSelf == false)
            {
                inventory.SetActive(true);
            }

            else if(Input.GetKeyDown(KeyCode.I) && inventory.activeSelf == true)
            {
                inventory.SetActive(false);
            }
        }
    }
}