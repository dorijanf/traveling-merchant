using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Route : MonoBehaviour
{
    [Header("References:")]
    public Transform[] waypoints;

    private Vector2 gizmosPosition;

    private void OnDrawGizmos()
    {
        for(float t = 0; t <= 1; t += 0.05f)
        {
            gizmosPosition = Mathf.Pow(1 - t, 3) * waypoints[0].position +
                3 * Mathf.Pow(1 - t, 2) * t * waypoints[1].position +
                3 * (1 - t) * Mathf.Pow(t, 2) * waypoints[2].position +
                Mathf.Pow(t, 3) * waypoints[3].position;

            Gizmos.DrawSphere(gizmosPosition, 0.2f);
        }

        Gizmos.DrawLine(new Vector2(waypoints[0].position.x, waypoints[0].position.y),
            new Vector2(waypoints[1].position.x, waypoints[1].position.y));

        Gizmos.DrawLine(new Vector2(waypoints[2].position.x, waypoints[2].position.y),
    new Vector2(waypoints[3].position.x, waypoints[3].position.y));
    }
}
