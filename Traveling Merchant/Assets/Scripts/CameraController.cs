using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Config Parameters:")]
    public Vector3 offset;
    public float smoothSpeed = 10f;

    [Space]
    [Header("References:")]
    public Transform target;
    

    private void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;
    }
}
