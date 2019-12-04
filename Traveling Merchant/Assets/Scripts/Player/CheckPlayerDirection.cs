using UnityEngine;

/*
 * Script that checks the direction our player is facing which is then used for other tasks
 */

public class CheckPlayerDirection : MonoBehaviour
{
    public enum Direction { North, East, South, West };
    private Direction dir;

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
            dir = Direction.East;
        }
        else if (horizontalValue < 0)
        {
            dir = Direction.West;
        }
        else
        {
            if (verticalValue > 0)
            {
                dir = Direction.North;
            }
            else
            {
                dir = Direction.South;
            }
        }
    }

    public Direction GetDirection()
    {
        return dir;
    }
}
