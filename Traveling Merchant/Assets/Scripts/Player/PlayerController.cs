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
    public bool isMounted;
    public bool isMounting;
    public Vector2 playerColliderSize;
    public bool movingOnYAxis;

    [Space]
    [Header("References:")]
    public Transform targetPos;
    public BoxCollider2D boxCollider;
    public Cart cart;
    private CheckPlayerDirection playerDir;
    private GameObject pickedUpObject;

    private void Start()
    {
        playerColliderSize = new Vector2(0.1f, 0.06f);
        playerDir = GetComponent<CheckPlayerDirection>();
        isMounting = false;
    }

    private void Update()
    {
        animator.SetFloat("IsSwinging", isSwinging);
        ChangeRotation();
        // DebugDrawBox(targetPos.position + offset, new Vector2(boxSizeX, boxSizeY), degrees, Color.red, 0.1f);
        if (!isMounted && !isMounting)
        {
            if (timeBetweenAttacks <= 0)
            {
                Interact();
            }
            else
            {
                timeBetweenAttacks -= Time.deltaTime;
            }
        }

        if (isMounted)
        {
            if (movingOnYAxis)
            {
                boxCollider.size = cart.colliderSizeVertical;
            }
            else
            {
                boxCollider.size = cart.colliderSizeHorizontal;
            }
        }
    }

    private void Interact()
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

        if (Input.GetKey(KeyCode.E) && isSwinging == 0.0f)
        {
            InteractWith();
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

    private void InteractWith()
    {
        Collider2D[] targetsToPickUp = Physics2D.OverlapBoxAll(targetPos.position + offset, new Vector2(boxSizeX, boxSizeY), degrees, whatIsTarget[1]);
        if (targetsToPickUp.Length != 0)
        {
            if (targetsToPickUp[0].gameObject.layer == LayerMask.NameToLayer("Item"))
            {
                targetsToPickUp[0].gameObject.GetComponent<MoveItem>().PickUp(gameObject);
            }
            else if(targetsToPickUp[0].gameObject.layer == LayerMask.NameToLayer("NPC"))
            {
                Debug.Log("Talking to NPC.");
            }
        }
        timeBetweenAttacks = startTimeBetweenAttacks;
    }

    private void ChangeRotation()
    {
        switch (playerDir.GetDirection())
        {
            case CheckPlayerDirection.Direction.North:
                movingOnYAxis = true;
                offset = new Vector3(0, offsetDistance, 0);
                degrees = 180f;
                boxCollider.transform.eulerAngles = new Vector3(0, 0, 90);
                break;
            case CheckPlayerDirection.Direction.West:
                movingOnYAxis = false;
                offset = new Vector3(-offsetDistance, 0, 0);
                degrees = 270f;
                boxCollider.transform.eulerAngles = new Vector3(0, 0, 0);
                break;
            case CheckPlayerDirection.Direction.East:
                movingOnYAxis = false;
                offset = new Vector3(offsetDistance, 0, 0);
                degrees = 90;
                boxCollider.transform.eulerAngles = new Vector3(0, 0, 0);
                break;
            case CheckPlayerDirection.Direction.South:
                movingOnYAxis = true;
                offset = new Vector3(0, -offsetDistance, 0);
                degrees = 0;
                boxCollider.transform.eulerAngles = new Vector3(0, 0, 90);
                break;
        }
    }

    // Only purpose of this function is debugging
    // The function displays the hitbox of the player in the scene view
    // Used for testing only
    /*
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
    */
}
