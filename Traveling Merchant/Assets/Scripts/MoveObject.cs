using UnityEngine.Rendering;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    [Header("References:")]
    public Rigidbody2D rigidBody;
    public SortingGroup sortingGroup;
    private Transform carryPosition;

    private void Start()
    {
        carryPosition = GameObject.Find("Carry Position").transform;
    }

    public GameObject CarryObject()
    {
        rigidBody.bodyType = RigidbodyType2D.Kinematic;
        gameObject.transform.position = carryPosition.position;
        gameObject.transform.SetParent(carryPosition.transform);
        sortingGroup.sortingOrder = 2;
        return gameObject;
    }

    public GameObject DropObject()
    {
        rigidBody.bodyType = RigidbodyType2D.Static;
        gameObject.transform.parent = null;
        gameObject.transform.position = carryPosition.position;
        sortingGroup.sortingOrder = 1;
        return null;
    }
}
