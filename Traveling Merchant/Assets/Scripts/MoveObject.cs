using UnityEngine.Rendering;
using UnityEngine;

/*
 * MoveObject script defines the behavior of objects when they are being moved via the PickUp and Drop functions.
 * When the objects are picked up they loose their collider, their parent the rigidbody changes its type from Static to 
 * Kinematic and its sorting order changes. When the object drops it reverts all these attributes to their original state
 * and lastly the StoreItem function defines what happens when the player drops the item inside the cart collider i.e. stores it.
 */
public class MoveObject : MonoBehaviour
{
    [Header("References:")]
    public Rigidbody2D rigidBody;
    public SortingGroup sortingGroup;
    public Item item;
    public BoxCollider2D boxCollider;

    private Transform carryPosition;

    private void Start()
    {
        carryPosition = GameObject.Find("Carry Position").transform;
    }

    public GameObject CarryObject()
    {
        Debug.Log("Item " + item.name + " picked up.");
        rigidBody.bodyType = RigidbodyType2D.Kinematic;
        gameObject.transform.position = carryPosition.position;
        gameObject.transform.SetParent(carryPosition.transform);
        boxCollider.enabled = false;
        sortingGroup.sortingOrder = sortingGroup.sortingOrder + 1;
        return gameObject;
    }

    public GameObject DropObject()
    {
        rigidBody.bodyType = RigidbodyType2D.Static;
        gameObject.transform.parent = null;
        gameObject.transform.position = carryPosition.position;
        boxCollider.enabled = true;
        sortingGroup.sortingOrder = 1;
        return null;
    }

    public void StoreItem()
    {
        Debug.Log("Item " + item.name + " stored.");
        bool wasPickedUp = Cart.instance.Add(item);
        if (wasPickedUp)
        {
            Destroy(gameObject);
        }
    }
}
