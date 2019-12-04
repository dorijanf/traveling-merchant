using UnityEngine;

/*
 * Helper script that allows the item to be dragged on screen
 */

public class ItemFollowCursor : MonoBehaviour
{
    private void LateUpdate()
    {
        transform.position = Input.mousePosition;
    }
}
