using System.Collections;
using UnityEngine;

public class DropItem : MonoBehaviour
{
    [Header("References:")]
    public Rigidbody2D rigidBody;
    public Collider2D polyCollider;

    [Space]
    [Header("Config Parameters:")]
    public float speed;

    private void Start()
    {
        transform.SetParent(null);
        StartCoroutine("AddGravity");
        polyCollider.enabled = false;
    }

    private IEnumerator AddGravity()
    {
        var flightDirection = Random.onUnitSphere;
        AddForce(flightDirection);
        yield return new WaitForSeconds(Random.Range(0.4f, 0.6f));
        AddForce(flightDirection);
        yield return new WaitForSeconds(0.4f);
        AddForce(flightDirection);
        yield return new WaitForSeconds(0.2f);
        AddForce(flightDirection);
        yield return new WaitForSeconds(0.1f);
        StopForce(flightDirection);
    }

    private void AddForce(Vector3 flightDirection)
    {
        rigidBody.gravityScale = 0f;
        rigidBody.velocity = flightDirection * speed;
        rigidBody.gravityScale = 0.2f;
    }

    private void StopForce(Vector3 flightDirection)
    {
        rigidBody.bodyType = RigidbodyType2D.Static;
        polyCollider.enabled = true;
    }
}
