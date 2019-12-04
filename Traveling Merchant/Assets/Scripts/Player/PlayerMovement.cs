using UnityEngine;

/*
 * Script that describes the way our player will be moved
 */

public class PlayerMovement : MonoBehaviour
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
    public PlayerController playerController;

    public float step;

    private void Update()
    {
        if (animator.GetFloat("IsSwinging") > 0 || playerController.isMounting)
        {
            rigidBody.velocity = Vector2.zero;
        }
        else
        {
            ProcessInput();
            Move();
            Animate();
        }
    }

    private void ProcessInput()
    {
        movementDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        movementSpeed = Mathf.Clamp(movementDirection.magnitude, 0.0f, 1.0f);
        movementDirection.Normalize();
    }

    public void Move()
    {
        step = movementSpeed * MOVEMENT_BASE_SPEED;
        rigidBody.velocity = movementDirection * step;
    }

    public void Animate()
    {
        if(movementDirection != Vector2.zero)
        {
            animator.SetFloat("Horizontal", movementDirection.x);
            animator.SetFloat("Vertical", movementDirection.y);
        }
        animator.SetFloat("Speed", movementSpeed);
    }
}