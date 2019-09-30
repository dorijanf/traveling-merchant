﻿using System.Collections;
using UnityEngine;

public class Item : MonoBehaviour
{
    [Header("References:")]
    public Rigidbody2D rigidBody;
    public Transform parent;
    public Transform player;
    public Collider2D boxCollider;

    [Space]
    [Header("Config Parameters:")]
    public float speed;

    [Space]
    [Header("Character Attributes:")]
    public int id;
    public string name;
    public string description;
    public Sprite icon;

    private void Start()
    {
        transform.SetParent(null);
        StartCoroutine("AddGravity");
        boxCollider.enabled = false;
        
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
        boxCollider.enabled = true;
    }
}