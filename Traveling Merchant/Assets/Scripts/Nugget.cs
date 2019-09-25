using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nugget : MonoBehaviour
{
    [Header("References:")]
    public Rigidbody2D rigidBody;
    public Transform parent;

    [Space]
    [Header("Config Parameters:")]
    public float speed;

    private void Start()
    {
        transform.SetParent(null);
        StartCoroutine("addGravity");
    }

    private IEnumerator addGravity()
    {
        rigidBody.velocity = Random.onUnitSphere * speed;
        rigidBody.gravityScale = 0.2f;
        yield return new WaitForSeconds(Random.Range(0.3f, 0.5f));
        rigidBody.gravityScale = 0f;
        rigidBody.velocity = new Vector2(0, 0);
    }
}
