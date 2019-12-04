using UnityEngine;

/*
 * IsNearObject is a script that checks if the player is near an object
 * and if it is it can be accessed through CheckIsNearObject function and 
 * it can be set with SetIsNearObject script
 */

public class IsNearObject : MonoBehaviour
{
    private bool isNearObject;
    private GameObject collision;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            this.collision = collision.gameObject;
            isNearObject = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isNearObject = false;
    }

    public bool CheckIsNearObject()
    {
        return isNearObject;
    }

    public void SetIsNearObject(bool isNearObject)
    {
        this.isNearObject = isNearObject;
    }

    public GameObject CheckCollisionObject()
    {
        return collision;
    }
}
