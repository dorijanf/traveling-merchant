using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPlayerDirection : MonoBehaviour
{
    private bool movingNorth;
    private bool movingWest;
    private bool movingEast;
    private bool movingSouth;

    [Header("References:")]
    public Animator animator;

    private void Update()
    {
        CheckDirection();
    }

    private void CheckDirection()
    {
        int horizontalID = Animator.StringToHash("Horizontal");
        int verticalID = Animator.StringToHash("Vertical");
        float horizontalValue = animator.GetFloat("Horizontal");
        float verticalValue = animator.GetFloat("Vertical");

        if (horizontalValue > 0)
        {
            movingWest = false;
            movingNorth = false;
            movingSouth = false;
            movingEast = true;
        }
        else if (horizontalValue < 0)
        {
            movingWest = true;
            movingNorth = false;
            movingSouth = false;
            movingEast = false;
        }
        else
        {
            if (verticalValue > 0)
            {
                movingWest = false;
                movingNorth = true;
                movingSouth = false;
                movingEast = false;
            }
            else
            {
                movingWest = false;
                movingNorth = false;
                movingSouth = true;
                movingEast = false;
            }
        }
    }

    public bool IsMovingNorth()
    {
        return movingNorth;
    }

    public bool IsMovingWest()
    {
        return movingWest;
    }

    public bool IsMovingEast()
    {
        return movingEast;
    }

    public bool IsMovingSouth()
    {
        return movingSouth;
    }
}
