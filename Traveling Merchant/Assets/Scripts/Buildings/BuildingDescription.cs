using UnityEngine;
using System.Collections.Generic;

public class BuildingDescription : MonoBehaviour
{
    [Header("References:")]
    public Building building;
    public SpriteRenderer spriteRenderer;

    [Space]
    [Header("Building Attributes:")]
    public int buildingLevel = 0;
    public string buildingName;
    public Sprite buildingSprite;
    public int buildingCost;
    public int[] resourceProduction;
    public List<int[]> resourceProductionList = new List<int[]>();
    public string resourceName1;
    public string resourceName2;
    public string resourceName3;


    private void Awake()
    {
        resourceProductionList.Add(building.resourceProduction0);
        resourceProductionList.Add(building.resourceProduction1);
        resourceProductionList.Add(building.resourceProduction2);
        resourceProductionList.Add(building.resourceProduction3);
        buildingName = building.name;
        buildingSprite = building.buildingSprite[buildingLevel];
        buildingCost = building.cost;
        spriteRenderer.sprite = buildingSprite;
        resourceName1 = building.resourceName1;
        resourceName2 = building.resourceName2;
        resourceName3 = building.resourceName3;
        resourceProduction = resourceProductionList[buildingLevel];
    }

    public void ChangeBuildingSprite()
    {
        buildingLevel += 1;
        buildingSprite = building.buildingSprite[buildingLevel];
        spriteRenderer.sprite = buildingSprite;
        resourceProduction = resourceProductionList[buildingLevel];
    }
}
