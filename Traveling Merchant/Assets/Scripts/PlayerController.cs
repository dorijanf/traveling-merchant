using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Config Parameters:")]
    public Vector2 movementDirection;
    public float movementSpeed;

    [Space]
    [Header("Character Attributes:")]
    public float MOVEMENT_BASE_SPEED = 1.0f;

    [Space]
    [Header("References:")]
    public Rigidbody2D rigidBody;
    public Animator animator;


    private void Update()
    {
        ProcessInput();
        Move();
        Animate();
    }

    private void ProcessInput()
    {
        movementDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        movementSpeed = Mathf.Clamp(movementDirection.magnitude, 0.0f, 1.0f);
        movementDirection.Normalize();
    }

    private void Move()
    {
        rigidBody.velocity = movementDirection * movementSpeed * MOVEMENT_BASE_SPEED;
    }

    private void Animate()
    {
        if(movementDirection != Vector2.zero)
        {
            animator.SetFloat("Horizontal", movementDirection.x);
            animator.SetFloat("Vertical", movementDirection.y);
        }
        animator.SetFloat("Speed", movementSpeed);
    }
}