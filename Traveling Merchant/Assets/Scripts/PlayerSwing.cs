using UnityEngine;

public class PlayerSwing : MonoBehaviour
{
    [Header("Config Parameters:")]
    public LayerMask whatIsTarget;
    public Vector3 offset;
    private float timeBetweenAttacks;
    public float degrees;

    [Space]
    [Header("Character Attributes:")]
    public int damage;
    public float boxSizeX;
    public float boxSizeY;
    public float startTimeBetweenAttacks;

    [Space]
    [Header("References:")]
    public Transform targetPos;

    private void Update()
    {
        if (timeBetweenAttacks <= 0)
        {
            Swing();
        }
        else
        {
            timeBetweenAttacks -= Time.deltaTime;
        }
    }

    private void Swing()
    {
        ChangeRotation();
        DebugDrawBox(targetPos.position + offset, new Vector2(boxSizeX, boxSizeY), degrees, Color.red, 0.1f);
        if (Input.GetKey(KeyCode.Space))
        {
            Collider2D[] targetsToDamage = Physics2D.OverlapBoxAll(targetPos.position + offset, new Vector2(boxSizeX, boxSizeY), degrees, whatIsTarget);
            for (int i = 0; i < targetsToDamage.Length; i++)
            {
                targetsToDamage[i].GetComponent<Resource>().TakeDamage(damage);
            }
            timeBetweenAttacks = startTimeBetweenAttacks;
        }
    }

    private void RotateBoxCollider(float degrees)
    {
        transform.eulerAngles = Vector3.forward * degrees;
    }

    private void ChangeRotation()
    {
        if (transform.parent.GetComponent<CheckPlayerDirection>().IsMovingNorth())
        {
            offset = new Vector3(0, 0.25f, 0);
            degrees = 180f;
        }
        else if (transform.parent.GetComponent<CheckPlayerDirection>().IsMovingWest())
        {
            offset = new Vector3(-0.25f, 0, 0);
            degrees = 270f;
        }
        else if (transform.parent.GetComponent<CheckPlayerDirection>().IsMovingEast())
        {
            offset = new Vector3(0.25f, 0, 0);
            degrees = 90;
        }
        else if (transform.parent.GetComponent<CheckPlayerDirection>().IsMovingSouth())
        {
            offset = new Vector3(0, -0.25f, 0);
            degrees = 0;
        }

        transform.rotation = Quaternion.Euler(Vector3.forward * degrees);
    }

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
