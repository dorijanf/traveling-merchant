using UnityEngine;

/*
 * PlayerController script defines player behaviour. It defines when the player can interact with an object
 * and in what way it can interact with it. Currently the script defines Swing, Drop and Pickup functions.
 */

public class PlayerController : MonoBehaviour
{
    [Header("Config Parameters:")]
    public LayerMask[] whatIsTarget;
    public float offsetDistance;
    public float degrees;
    public Animator animator;
    private float timeBetweenAttacks;
    private Vector3 offset;

    [Space]
    [Header("Character Attributes:")]
    public int damage;
    public float boxSizeX;
    public float boxSizeY;
    public float startTimeBetweenAttacks;
    public float isSwinging;

    [Space]
    [Header("References:")]
    public Transform targetPos;
    private CheckPlayerDirection playerDir;
    private GameObject pickedUpObject;

    private void Start()
    {
        playerDir = GetComponent<CheckPlayerDirection>();
    }

    private void Update()
    {
        animator.SetFloat("IsSwinging", isSwinging);
        ChangeRotation();
        DebugDrawBox(targetPos.position + offset, new Vector2(boxSizeX, boxSizeY), degrees, Color.red, 0.1f);

        if (timeBetweenAttacks <= 0)
        {
            Interact();
        }
        else
        {
            timeBetweenAttacks -= Time.deltaTime;
        }
    }

    private void Interact()
    {
        if (pickedUpObject == null)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                isSwinging = 1f;
                Swing();
            }
            else
            {
                isSwinging = 0.0f;
            }

            if(Input.GetKey(KeyCode.E) && isSwinging == 0.0f)
            {
                PickUp();
            }
        }
        else 
        {
            if (Input.GetKey(KeyCode.F))
            {
                Drop();
            }
        }
    }

    private void Swing()
    {
        Collider2D[] targetsToDamage = Physics2D.OverlapBoxAll(targetPos.position + offset, new Vector2(boxSizeX, boxSizeY), degrees, whatIsTarget[0]);
        for (int i = 0; i < targetsToDamage.Length; i++)
        {
            targetsToDamage[i].GetComponent<Resource>().TakeDamage(damage);
        }
        timeBetweenAttacks = startTimeBetweenAttacks;
    }

    private void PickUp()
    {
        Collider2D[] targetsToPickUp = Physics2D.OverlapBoxAll(targetPos.position + offset, new Vector2(boxSizeX, boxSizeY), degrees, whatIsTarget[1]);
        if (targetsToPickUp.Length != 0)
        {
            pickedUpObject = targetsToPickUp[0].GetComponent<MoveItem>().CarryObject();
        }
    }

    private void Drop()
    {
        pickedUpObject = pickedUpObject.GetComponent<MoveItem>().DropObject(targetPos.position + offset);
    }

    private void ChangeRotation()
    {
        switch (playerDir.GetDirection())
        {
            case CheckPlayerDirection.Direction.North:
                offset = new Vector3(0, offsetDistance, 0);
                degrees = 180f;
                break;
            case CheckPlayerDirection.Direction.West:
                offset = new Vector3(-offsetDistance, 0, 0);
                degrees = 270f;
                break;
            case CheckPlayerDirection.Direction.East:
                offset = new Vector3(offsetDistance, 0, 0);
                degrees = 90;
                break;
            case CheckPlayerDirection.Direction.South:
                offset = new Vector3(0, -offsetDistance, 0);
                degrees = 0;
                break;
        }
    }

    // Only purpose of this function is debugging
    // The function displays the hitbox of the player in the scene view
    // Used for testing only
    void DebugDrawBox(Vector2 point, Vector2 size, float angle, Color color, float duration)
    {
        var orientation = Quaternion.Euler(0, 0, angle);

        // Basis vectors, half the size in each direction from the center.
        Vector2 right = orientation * Vector2.right * size.x / 2f;
        Vector2 up = orientation * Vector2.up * size.y / 2f;

        // Four box corners.
        var topLeft = point + up - right;
        var topRight = point + up + right;
        var bottomRight = point - up + right;
        var bottomLeft = point - up - right;

        // Now we've reduced the problem to drawing lines.
        Debug.DrawLine(topLeft, topRight, color, duration);
        Debug.DrawLine(topRight, bottomRight, color, duration);
        Debug.DrawLine(bottomRight, bottomLeft, color, duration);
        Debug.DrawLine(bottomLeft, topLeft, color, duration);
    }
}
