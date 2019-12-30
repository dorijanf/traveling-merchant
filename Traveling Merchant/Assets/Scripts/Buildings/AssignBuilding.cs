using UnityEngine;
using UnityEngine.UI;

public class AssignBuilding : MonoBehaviour
{
    public InventoryUI inventoryUI;
    public Text inventoryName;
    public Image resource1;
    public Image resource2;
    public Image resource3;
    public Text resourceName1;
    public Text resourceName2;
    public Text resourceName3;
    public Text dailyIncome1;
    public Text dailyIncome2;
    public Text dailyIncome3;
    public Text upgradePrice;

    private void Start()
    {
        inventoryName.text = InventoryDatabase.inventory[inventoryUI.inventoryId].gameObject.GetComponent<BuildingDescription>().buildingName;
        /*resource1 = InventoryDatabase.inventory[inventoryUI.inventoryId].gameObject.GetComponent<AssignBuilding>().resource1;
        resource2 = InventoryDatabase.inventory[inventoryUI.inventoryId].gameObject.GetComponent<AssignBuilding>().resource2;
        resource3 = InventoryDatabase.inventory[inventoryUI.inventoryId].gameObject.GetComponent<AssignBuilding>().resource3;*/
        resourceName1.text = InventoryDatabase.inventory[inventoryUI.inventoryId].gameObject.GetComponent<BuildingDescription>().resourceName1;
        resourceName2.text = InventoryDatabase.inventory[inventoryUI.inventoryId].gameObject.GetComponent<BuildingDescription>().resourceName2;
        resourceName3.text = InventoryDatabase.inventory[inventoryUI.inventoryId].gameObject.GetComponent<BuildingDescription>().resourceName3;
    }

    private void Update()
    {
        dailyIncome1.text = InventoryDatabase.inventory[inventoryUI.inventoryId].gameObject.GetComponent<BuildingDescription>().resourceProduction[0].ToString();
        dailyIncome2.text = InventoryDatabase.inventory[inventoryUI.inventoryId].gameObject.GetComponent<BuildingDescription>().resourceProduction[1].ToString();
        dailyIncome3.text = InventoryDatabase.inventory[inventoryUI.inventoryId].gameObject.GetComponent<BuildingDescription>().resourceProduction[2].ToString();
        upgradePrice.text = InventoryDatabase.inventory[inventoryUI.inventoryId].gameObject.GetComponent<BuildingDescription>().buildingCost.ToString();
    }
}
