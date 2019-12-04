using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AssignId
{
    public static int inventoryId = 0;

    public static void AssignInventoryId()
    {
        inventoryId += 1;
    }
}
