using System.Collections;
using System.Collections.Generic;
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

    void Update()
    {
        ProcessInput();
        Move();
        Animate();
    }

    void ProcessInput()
    {
        movementDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        movementSpeed = Mathf.Clamp(movementDirection.magnitude, 0.0f, 1.0f);
        movementDirection.Normalize();
    }

    void Move()
    {
        if (movementDirection.x > 0.5f || movementDirection.x < -0.5f)
        {
            rigidBody.velocity = new Vector2(movementDirection.x * movementSpeed * MOVEMENT_BASE_SPEED, 0f);
        }
        else if (movementDirection.y > 0.5f || movementDirection.y < -0.5f)
        {
            rigidBody.velocity = new Vector2(0f, movementDirection.y * movementSpeed * MOVEMENT_BASE_SPEED);
        }
        else
        {
            rigidBody.velocity = new Vector2(0, 0);
        }
    }

    void Animate()
    {
        animator.SetFloat("Horizontal", movementDirection.x);
        animator.SetFloat("Vertical", movementDirection.y);
        animator.SetFloat("Speed", movementSpeed);
    }
}