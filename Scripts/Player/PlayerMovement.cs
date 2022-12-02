using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement Instance { get; private set; } = null;

    //Animation Parameters
    private const string animParameterlSpeed = "speed";

    //Inputs
    private WeaponComponentens weaponComponentens;
    private PlayerInput playerInput;
    private Camera camera;


    // Player Comp
    [SerializeField] private Rigidbody2D body;
    [SerializeField] private float moveSpeed = 5f;
    private Animator myAnimator;
    private PlayerLife myPlayerLife = null;

    [SerializeField] private GameObject iceSprite;

    // Movement
    private Vector2 movementInputVector;
    private Vector2 newPosition;

    private bool hasWeapon = false;
    private bool canMove = false;

    private bool isFrozen = false;
    private float freezeTimer = 0;


    public void CanMove(bool value)
    {
        canMove = value;
    }

    public bool PlayerHasGun()
    {
        return hasWeapon;
    }

    public void HasGun()
    {
        hasWeapon = true;
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        playerInput = new PlayerInput();
        body = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myPlayerLife = GetComponent<PlayerLife>();
        camera = GetComponent<Camera>();
    }

    private void Start()
    {
        camera = Camera.main;
        playerInput = InputManager.Instance.GetInputActions();
    }

    private void Update()
    {
        if (!myPlayerLife.IsDead())
        {
            Movement();
            WithGun();
        }
    }

    private void WithGun()
    {
        if (hasWeapon)
        {
            Rotate();
        }
        else
        {
            CheckDirectionSprite();
        }
    }

    private void Movement()
    {
        if (!canMove)
        {
            myAnimator.SetFloat(animParameterlSpeed, 0);
            InputManager.Instance.ToggleInputActionsState(false);
        }
        else if (canMove)
        {
            InputManager.Instance.ToggleInputActionsState(true);
            movementInputVector = playerInput.player.movement.ReadValue<Vector2>();
            body.velocity = movementInputVector * moveSpeed;
            myAnimator.SetFloat(animParameterlSpeed, Mathf.Abs(body.velocity.x + body.velocity.y));
        }
    }

    private void CheckDirectionSprite()
    {
        if ((transform.right.x > 0 && movementInputVector.x < 0 ||
             transform.right.x < 0 && movementInputVector.x > 0))
        {
            newPosition = this.transform.localEulerAngles;
            newPosition.y += 180f;
            transform.localEulerAngles = newPosition;
        }
    }

    // Player flip according the weapon position
    private void Rotate()
    {
        Vector2 mouse = playerInput.player.mousePosition.ReadValue<Vector2>();
        Vector2 pos = new Vector2(mouse.x, mouse.y);
        float worldXPos = camera.ScreenToWorldPoint(pos).x;

        if (worldXPos < this.transform.position.x)
        {
            newPosition.y = 180f;
        }
        else
        {
            newPosition.y = 0f;
        }

        transform.localEulerAngles = newPosition;
    }


    private void FixedUpdate()
    {
        if (isFrozen = true && freezeTimer > 0)
        {
            freezeTimer -= Time.deltaTime;
            InputManager.Instance.ToggleInputActionsState(false);
            isFrozen = true;
            iceSprite.SetActive(true);
        }
        else
        {
            InputManager.Instance.ToggleInputActionsState(true);
            isFrozen = false;
            iceSprite.SetActive(false);
        }
    }

    public void Hit(int damage, float freezTime)
    {
        isFrozen = true;
        freezeTimer = freezTime;
    }
}