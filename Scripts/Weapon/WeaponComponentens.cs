using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WeaponComponentens : MonoBehaviour
{
    public static WeaponComponentens Instance { get; private set; } = null;

    //External files
    private PlayerInput playerInput;
    private Camera camera;
    private PlayerMovement playerMovement;
    private Animator myAnimator;

    //Weapon Components
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject weapon;
    [SerializeField] private Transform bulletDirection;
    [SerializeField] private GameObject crossAir;
    [SerializeField] private float speed = 8f;
    [SerializeField] private float angleOfset = -3f;

    [SerializeField] private float timeBtwShots = 0.5f;

    //Direction
    private float angle;
    private float movementDirection = 0f;
    private bool canShoot = true;

    //Vectors Mouse
    private Vector2 mouseScreenPosition;
    private Vector2 aim;
    private Vector3 mouseWorldPosition;
    private Vector3 targetDirection;

    //has player
    private bool hasPlayer = false;
    private bool shoot = false;

    // AudioComponents
    [SerializeField] private AudioClip playerShootingSound;


    public void DestroyObject()
    {
        Destroy(gameObject);
    }

    public void HasPlayer()
    {
        hasPlayer = true;
    }

    private void Awake()
    {
        camera = GetComponent<Camera>();
        playerInput = new PlayerInput();
        myAnimator = GetComponent<Animator>();
    }

    private void Start()
    {
        camera = Camera.main;
        playerInput = InputManager.Instance.GetInputActions();
    }

    private void Update()
    {
        if (hasPlayer && canShoot == true)
        {
            MouseRotation();
            PlayerShoot();
        }
    }

    private void PlayerShoot()
    {
        shoot = playerInput.player.shoot.triggered;
        if (hasPlayer && !PlayerLife.Instance.IsDead())
        {
            if (shoot == true)
            {
                FireBullet();
                StartCoroutine(CanShoot());
            }
        }
    }


    private void FireBullet()
    {
        AudioSource.PlayClipAtPoint(playerShootingSound, transform.position, 0.5f);
        myAnimator.SetTrigger("shoot");
        var bullet = PoolManager.Use(bulletPrefab,
            bulletDirection.position, bulletDirection.rotation);

        bullet.GetComponent<Rigidbody2D>().velocity =
            bulletDirection.right * speed;
    }

    IEnumerator CanShoot()
    {
        canShoot = false;
        yield return new WaitForSeconds(timeBtwShots);
        canShoot = true;
    }


    private void MouseRotation()
    {
        mouseScreenPosition = playerInput.player.mousePosition.ReadValue<Vector2>();
        mouseWorldPosition = camera.ScreenToWorldPoint(mouseScreenPosition);
        targetDirection = (mouseWorldPosition - transform.position).normalized;
        angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0f, 0f, angle + angleOfset);
        if (angle + angleOfset < -90 || angle + angleOfset > 90)
        {
            if (weapon.transform.eulerAngles.y == 0)
            {
                transform.eulerAngles = new Vector3(180, 0, (-angle + angleOfset));
            }
            else if (weapon.transform.eulerAngles.y == 180)
            {
                transform.eulerAngles = new Vector3(180, 180, (-angle + angleOfset));
            }
        }
    }
}