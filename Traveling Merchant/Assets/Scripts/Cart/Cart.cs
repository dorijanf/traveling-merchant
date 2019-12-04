using UnityEngine;

/*
 * Script that describes the states and attributes of the cart and also describes its behaviour
 */

public class Cart : MonoBehaviour
{
    [Header("References:")]
    public GameObject mountPoint;
    public GameObject player;
    public BoxCollider2D boxCollider;
    private PlayerController playerController;
    private SpriteRenderer spriteRenderer;

    [Space]
    [Header("Character Attributes:")]
    public Vector2 colliderSizeVertical;
    public Vector2 colliderSizeHorizontal;

    private void Awake()
    {
        playerController = player.GetComponent<PlayerController>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void Start()
    {
        colliderSizeVertical = new Vector2(0.5f, 0.3f);
        colliderSizeHorizontal = new Vector2(0.5f, 0.1f);
    }

    private void Update()
    {
        if (playerController.isMounted)
        {
            boxCollider.enabled = false;
            spriteRenderer.enabled = false;
            gameObject.transform.position = player.transform.position;
        }

        if (!playerController.isMounted)
        {
            boxCollider.enabled = true;
            spriteRenderer.enabled = true;
            gameObject.transform.position = transform.position;
        }
    }
}
