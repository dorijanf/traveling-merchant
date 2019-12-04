using System.Collections.Generic;
using UnityEngine;

/*
 * Helper class which contains functions which can be used to help with various tasks
 */

public static class Utilities
{
    public static void LookAt2D(this Transform transform, Vector2 target)
    {
        Vector2 current = transform.position;
        var direction = target - current;
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    public static GameObject FindClosestGameObject(GameObject player, List<GameObject> objects)
    {
        var shortestDistance = Mathf.Infinity;
        GameObject closestGameObject = null;
        for(int i = 0; i < objects.Capacity; i++)
        {
            var distance = Vector3.Distance(player.transform.position, objects[i].transform.position);
            if(distance <= shortestDistance)
            {
                shortestDistance = distance;
                closestGameObject = objects[i];
            }
        }
        return closestGameObject;
    }

    public static GameObject[] FindClosestGameObjects(GameObject player, List<GameObject> objects)
    {
        var shortestDistance = Mathf.Infinity;
        GameObject[] closestGameObjects = null;
        for (int i = 0; i < objects.Capacity; i++)
        {
            var distance = Vector3.Distance(player.transform.position, objects[i].transform.position);
            if (distance <= shortestDistance && closestGameObjects.Length <= 1)
            {
                shortestDistance = distance;
                closestGameObjects[i] = objects[i];
            }
        }
        return closestGameObjects;
    }
}
