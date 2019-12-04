using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBuildingUI : MonoBehaviour
{
    [Header("References:")]
    public Inventory inventory;
    public IsNearObject isNearObject;

    private void Update()
    {
        openUI();
        UISetActive();
    }

    private void UISetActive()
    {
        if (!isNearObject.CheckIsNearObject())
        {
            inventory.inventoryUI.gameObject.SetActive(false);
        }
    }

    private void openUI()
    {
        if (isNearObject.CheckIsNearObject())
        {
            inventory.inventoryUI.gameObject.SetActive(true);
        }
    }
}
