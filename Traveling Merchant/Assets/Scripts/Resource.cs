using UnityEngine;

public class Resource : MonoBehaviour
{
    [Header("Resource Attributes:")]
    public int health;

    [Space]
    [Header("References:")]
    public GameObject nugget;

    private void Update()
    {
        DestroyResource();
    }

    public void TakeDamage(int damage)
    {
        health = health - damage;
        Instantiate(nugget, transform.position, Quaternion.identity);
    }

    public void DestroyResource()
    {
        if(health == 0)
        {
            Destroy(gameObject);
        }
    }
}
