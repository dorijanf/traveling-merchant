using System;
using UnityEngine;
using UnityEngine.UI;

public class BuildingUpgrade : MonoBehaviour
{
    [Header("References:")]
    public Inventory inventory;
    public IsNearObject isNearObject;
    public BuildingDescription buildingDescription;
    public Button button;

    public void Start()
    {
        button = inventory.inventoryUI.gameObject.GetComponentInChildren<Button>();
        button.onClick.AddListener(this.gameObject.GetComponent<BuildingUpgrade>().UpgradeBuilding);
    }

    private void Update()
    {
        if(buildingDescription.buildingLevel == buildingDescription.building.buildingSprite.Length)
        {
            button.interactable = false;
        }
    }

    public void UpgradeBuilding()
    {
        if (isNearObject.CheckCollisionObject().transform.parent.GetComponent<Gold>().gold >= buildingDescription.buildingCost)
        {
            buildingDescription.ChangeBuildingSprite();
            isNearObject.CheckCollisionObject().transform.parent.GetComponent<Gold>().gold -= buildingDescription.buildingCost;
        }
        else
        {
            Debug.Log("Insufficient funds");
        }
    }
}
