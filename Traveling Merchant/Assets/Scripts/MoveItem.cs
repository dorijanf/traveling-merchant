using UnityEngine;

public class MoveItem : MonoBehaviour
{
    [Header("References:")]
    public Rigidbody2D rigidBody;
    public Item item;

    private void Start()
    {

    }

    public void PickUp()
    {
        Debug.Log("Item " + item.name + " picked up.");
        bool wasPickedUp = PlayerInventory.instance.Add(item);
        if (wasPickedUp)
        {
            Destroy(gameObject);
        }
    }

    public GameObject DropObject(Vector2 dropPosition)
    {
        //DROP THE ITEM AT A LOCATION
        return null;
    }
}
