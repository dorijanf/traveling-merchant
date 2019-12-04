using System.Collections.Generic;
using UnityEngine;

/*
 * Mount is a script that describes the behaviour of the player
 * when mounting or dismounting the cart
 */

public class Mount : MonoBehaviour
{
    [Header("References:")]
    public GameObject player;
    public GameObject mountPoint;
    public GameObject cart;
    public GameObject boxColliderObject;
    public IsNearObject isNearObjectScript;
    public BoxCollider2D playerCollider;
    public List<GameObject> travelNodes;
    public List<Sprite> cartSprites;
    private GameObject closestTravelPoint;
    private GameObject closestTravelPoints;
    private Cart cartAttributes;
    private BoxCollider2D boxCollider;
    private PlayerController playerController;
    private PlayerMovement playerMovement;
    private List<GameObject> travelNodesCopy;
    private CheckPlayerDirection playerDir;
    private SpriteRenderer cartSprite;

    [Space]
    [Header("Config Parameters:")]
    public Vector2 cartColliderVertical;
    public Vector2 cartColliderHorizontal;
    private float playerOldPositionX = 0.0f;
    private float playerOldPositionY = 0.0f;
    private bool isMounting;

    private void Awake()
    {
        playerMovement = player.GetComponent<PlayerMovement>();
        playerController = player.GetComponent<PlayerController>();
        playerDir = player.GetComponent<CheckPlayerDirection>();
        cartSprite = cart.GetComponentInChildren<SpriteRenderer>();
        boxCollider = boxColliderObject.GetComponent<BoxCollider2D>();
        cartAttributes = cart.GetComponent<Cart>();
    }

    private void Start()
    {
        cartColliderVertical = new Vector2(0.4f, 0.3f);
        cartColliderHorizontal = new Vector2(0.3f, 0.25f);
        travelNodesCopy = new List<GameObject>(travelNodes);
        isMounting = false;
        playerOldPositionX = transform.position.x;
        playerOldPositionY = transform.position.y;
    }

    private void Update()
    {
        onMountKeyPress();
        Mounting();
    }

    private void Mounting()
    {
        if (isMounting)
        {
            isNearObjectScript.SetIsNearObject(true);
            playerCollider.enabled = false;
            playerController.isMounting = true;
            closestTravelPoint = Utilities.FindClosestGameObject(player, travelNodesCopy);
            if (closestTravelPoint.name != "Mount Point")
            {
                player.transform.position = Vector2.MoveTowards(player.transform.position, closestTravelPoint.transform.position, playerMovement.MOVEMENT_BASE_SPEED * Time.deltaTime);
                playerMovement.animator.SetFloat("Speed", 1);
                CalculateAnimation();
            }
            else
            {
                player.transform.position = Vector2.MoveTowards(player.transform.position, mountPoint.transform.position, playerMovement.MOVEMENT_BASE_SPEED * Time.deltaTime);
                playerMovement.animator.SetFloat("Speed", 1);
                CalculateAnimation();
            }

            if (Vector2.Distance(player.transform.position, closestTravelPoint.transform.position) < 0.001f)
            {
                travelNodesCopy.Remove(closestTravelPoint);
                travelNodesCopy.Capacity = travelNodesCopy.Capacity - 1;
            }
        }

        if (Vector2.Distance(player.transform.position, mountPoint.transform.position) < 0.001f)
        {
            player.transform.position = Vector2.MoveTowards(player.transform.position, closestTravelPoint.transform.position, playerMovement.MOVEMENT_BASE_SPEED * Time.deltaTime);
            playerController.isMounting = false;
            travelNodesCopy = new List<GameObject>(travelNodes);
            isMounting = false;
            playerController.isMounted = true;
            ChangeDirectionOnMount();
            playerCollider.enabled = true;
        }
    }

    private void Dismount()
    {
        playerCollider.size = playerController.playerColliderSize;
        playerController.isMounted = false;
        isNearObjectScript.SetIsNearObject(true);
        playerMovement.animator.SetBool("isMounted", false);
        ChangeRotation();
    }

    private void ChangeDirectionOnMount()
    {
        playerMovement.animator.SetBool("isMounted", true);
        if (playerMovement.animator.GetFloat("Horizontal") == 1)
        {
            playerMovement.animator.SetFloat("Horizontal", -1);
        }
        else if (playerMovement.animator.GetFloat("Horizontal") == -1)
        {
            playerMovement.animator.SetFloat("Horizontal", 1);
        }

        if (playerMovement.animator.GetFloat("Vertical") == -1)
        {
            playerMovement.animator.SetFloat("Vertical", 1);
        }
        else if (playerMovement.animator.GetFloat("Vertical") == 1)
        {
            playerMovement.animator.SetFloat("Vertical", -1);
        }
    }

    private void CalculateAnimation()
    {
        if (player.transform.position.x > playerOldPositionX)
        {
            playerMovement.animator.SetFloat("Horizontal", 1);
            playerMovement.animator.SetFloat("Vertical", 0);
        }
        else if (player.transform.position.x < playerOldPositionX)
        {
            playerMovement.animator.SetFloat("Horizontal", -1);
            playerMovement.animator.SetFloat("Vertical", 0);
        }
        else if (player.transform.position.y > playerOldPositionY)
        {
            playerMovement.animator.SetFloat("Horizontal", 0);
            playerMovement.animator.SetFloat("Vertical", 1);
        }
        else if (player.transform.position.y < playerOldPositionY)
        {
            playerMovement.animator.SetFloat("Horizontal", 0);
            playerMovement.animator.SetFloat("Vertical", -1);
        }
        playerOldPositionX = player.transform.position.x;
        playerOldPositionY = player.transform.position.y;
    }

    private void ChangeRotation()
    {
        switch (playerDir.GetDirection())
        {
            case CheckPlayerDirection.Direction.North:
                boxCollider.transform.eulerAngles = new Vector3(0, 0, 90);
                boxCollider.offset = new Vector2(-0.03f, 0.0f);
                boxCollider.size = cartColliderVertical;
                mountPoint.transform.localPosition = new Vector2(0, 0.15f);
                cartSprite.sprite = cartSprites[0];
                break;
            case CheckPlayerDirection.Direction.West:
                boxCollider.transform.eulerAngles = new Vector3(0, 0, 0);
                boxCollider.offset = new Vector2(0.06f, -0.03f);
                boxCollider.size = cartColliderHorizontal;
                mountPoint.transform.localPosition = new Vector2(-0.15f, 0);
                cartSprite.sprite = cartSprites[1];
                break;
            case CheckPlayerDirection.Direction.East:
                boxCollider.transform.eulerAngles = new Vector3(0, 0, 0);
                boxCollider.offset = new Vector2(-0.06f, -0.03f);
                boxCollider.size = cartColliderHorizontal;
                mountPoint.transform.localPosition = new Vector2(0.15f, 0);
                cartSprite.sprite = cartSprites[2];
                break;
            case CheckPlayerDirection.Direction.South:
                boxCollider.transform.eulerAngles = new Vector3(0, 0, 90);
                boxCollider.offset = new Vector2(0.03f, 0.0f);
                boxCollider.size = cartColliderVertical;
                mountPoint.transform.localPosition = new Vector2(0, -0.15f);
                cartSprite.sprite = cartSprites[3];
                break;
        }
    }

    private void onMountKeyPress()
    {
        if (isNearObjectScript.CheckIsNearObject())
        {
            if (Input.GetKeyDown(KeyCode.C) && playerController.isMounted == false)
            {
                isMounting = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.C) && playerController.isMounted == true)
        {
            Dismount();
        }
    }
}
