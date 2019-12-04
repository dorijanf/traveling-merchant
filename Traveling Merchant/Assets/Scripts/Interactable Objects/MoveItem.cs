using UnityEngine;

/*
 * MoveItem is a script which defines what happens when the player picks up an item from the ground
 */

public class MoveItem : MonoBehaviour
{
    [Header("References:")]
    public Rigidbody2D rigidBody;
    public Item item;

    [Space]
    [Header("Config Parameters:")]
    public int id;

    public void PickUp(GameObject player)
    {
        bool wasPickedUp = player.GetComponent<Inventory>().GiveItem(id, player.GetComponent<Inventory>().inventoryId);
        if (wasPickedUp)
        {
            Destroy(gameObject);
        }
    }
}
