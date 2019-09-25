using UnityEngine;

public class PlayerSwing : MonoBehaviour
{
    public LayerMask whatIsTarget;
    public Vector3 offset;
    private float timeBetweenAttacks;
    private float degrees;

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
        ChangeRotation();
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
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("KEY PRESSED.");
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
            RotateBoxCollider(180f);

        }
        else if (transform.parent.GetComponent<CheckPlayerDirection>().IsMovingWest())
        {
            RotateBoxCollider(270f);
        }
        else if (transform.parent.GetComponent<CheckPlayerDirection>().IsMovingEast())
        {
            RotateBoxCollider(90f);
        }
        else if (transform.parent.GetComponent<CheckPlayerDirection>().IsMovingSouth())
        {
            RotateBoxCollider(0f);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(targetPos.position + offset, new Vector2(boxSizeX, boxSizeY));
        
    }
}
