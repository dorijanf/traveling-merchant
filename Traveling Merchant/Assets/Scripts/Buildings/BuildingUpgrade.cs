using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingUpgrade : MonoBehaviour
{
    [Header("References:")]
    public IsNearObject isNearObject;
    public BuildingDescription buildingDescription;

    private void Update()
    {
        UpgradeBuilding();
    }

    private void UpgradeBuilding()
    {
        if (isNearObject.CheckIsNearObject())
        {
            if (buildingDescription.buildingCost <= isNearObject.CheckCollisionObject().transform.parent.GetComponent<Gold>().gold)
            {
                buildingDescription.ChangeBuildingSprite();
                isNearObject.CheckCollisionObject().transform.parent.GetComponent<Gold>().gold -= buildingDescription.buildingCost;
            }
        }
    }
}
